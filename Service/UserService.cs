using AutoMapper;
using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Service.Contracts;
using Shared.Dtos;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class UserService : IUserService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;
        private ApplicationUser? _user;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper,
                UserManager<ApplicationUser> userManager, IConfiguration configuration,
                RoleManager<IdentityRole> roleManager)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
            _userManager = userManager;
            _configuration = configuration;
            _roleManager = roleManager;
        }

        public async Task<IdentityResult> RegisterUser(UserForRegistrationDto userForRegistration)
        {
            try
            {
                var CheckRole= await _repository.User.ValidateRolesAsync(userForRegistration.Roles);
                if (!CheckRole)
                    return null;

                var user = _mapper.Map<ApplicationUser>(userForRegistration);
                
                var result = await _userManager.CreateAsync(user, userForRegistration.Password);
                if (result.Succeeded)
                    await _userManager.AddToRolesAsync(user, userForRegistration.Roles);
                _repository.Save();
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the { nameof(RegisterUser)} service method {ex}");
                 throw;
            }

        }

        public async Task<bool> ValidateUser(UserForAuthenticationDto userForAuth)
        {
            _user = await _userManager.FindByNameAsync(userForAuth.UserName);
            var result = (_user != null && await _userManager.CheckPasswordAsync(_user, userForAuth.Password));
            if (!result)
                _logger.LogWarn($"{nameof(ValidateUser)}: Authentication failed. Wrong username or password.");
            return result;
        }

        public async Task<string> CreateToken()
        {
            var signingCredentials = GetSigningCredentials();
            var claims = await GetClaims();
            var tokenOptions = GenerateTokenOptions(signingCredentials, claims);
            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        }

        private SigningCredentials GetSigningCredentials()
        {
            // قراءة المفتاح السري من appsettings.json
            var secretKey = _configuration.GetSection("JwtSettings")["secretKey"];
            var key = Encoding.UTF8.GetBytes(secretKey);
            var secret = new SymmetricSecurityKey(key);
            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }

        private async Task<List<Claim>> GetClaims()
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, _user.UserName)
            };
            var roles = await _userManager.GetRolesAsync(_user);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            return claims;
        }

        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var tokenOptions = new JwtSecurityToken
            (
                issuer: jwtSettings["validIssuer"],
                audience: jwtSettings["validAudience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings["expires"])),  // قراءة مدة صلاحية التوكن
                signingCredentials: signingCredentials
            );
            return tokenOptions;
        }


        public async Task<bool> AssignRoleToUserAsync(string userName, string role)
        {
            var user = await _userManager.FindByNameAsync(userName);
            if (user == null)
            {
                _logger.LogWarn("User not found.");
                return false;
            }

            var roleExists = await _roleManager.RoleExistsAsync(role);
            if (!roleExists)
            {
                _logger.LogWarn("Role does not exist.");
                return false;
            }

            var result = await _userManager.AddToRoleAsync(user, role);
            if (!result.Succeeded)
            {
                _logger.LogWarn($"Failed to assign role {role} to user {userName}.");
                return false;
            }

            _logger.LogInfo($"Successfully assigned role {role} to user {userName}.");
            return true;
        }


        public async Task<bool> ChangePasswordAsync(string userName, string oldPassword, string newPassword)
        {
            var user = await _userManager.FindByNameAsync(userName);
            if (user == null)
            {
                _logger.LogWarn("User not found.");
                return false;
            }

            var result = await _userManager.ChangePasswordAsync(user, oldPassword, newPassword);
            if (result.Succeeded)
            {
                _logger.LogInfo($"Password for user {userName} changed successfully.");
                return true;
            }
            else
            {
                _logger.LogWarn($"Failed to change password for user {userName}. Errors: {string.Join(", ", result.Errors.Select(e => e.Description))}");
                return false;
            }
        }


    }
}
