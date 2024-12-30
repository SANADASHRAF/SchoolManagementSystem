using AutoMapper;
using Contracts;
using Entities.Models;
using FluentNHibernate.Conventions.Inspections;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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
            var token=new JwtSecurityTokenHandler().WriteToken(tokenOptions);
            _user.Token= token;
            _repository.Save();
            return token ;
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
            _user = await _userManager.Users
            .Include(u => u.ApplicationUserImage) 
            .ThenInclude(ai => ai.Image) 
            .FirstOrDefaultAsync(u => u.Id == _user.Id);
            var claims = new List<Claim>
            {
                new Claim("Name", _user.Name ?? string.Empty), 
                new Claim("UserName", _user.UserName ?? string.Empty), 
                new Claim("Email", _user.Email?? string.Empty), 
                new Claim("Id", _user.Id?? string.Empty), 
                new Claim("Gender", _user.Gender?? string.Empty), 
                new Claim("Adress", _user.Address?? string.Empty), 
                new Claim("ImageUrl", _user.ApplicationUserImage?.Image?.ImageUrl ?? string.Empty), 
             
            };

            
            var roles = await _userManager.GetRolesAsync(_user);
            foreach (var role in roles)
            {
                claims.Add(new Claim("Roles", role));
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


        public async Task<string> SoftDeleteUser(string userId)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(userId);
                if (user == null)
                    return "User not found!";
                
                user.IsDeleted = true;
                var result = await _userManager.UpdateAsync(user);

                if (result.Succeeded)
                {
                    _logger.LogInfo($"User with ID {userId} has been soft deleted.");
                    return "User deleted successfully!";
                }
                else
                {
                    return "Failed to  deleted User.";
                }
            }
            catch (Exception ex)
            {
                return $" {ex.Message}";
            }
        }

       public async Task<string> LogedOut(string userId)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(userId);
                if (user == null)
                    return "User not found!";
                user.Token = null;
                _repository.Save();
                return null;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        //

        public async Task<List<string>> GetAppRoles()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            var roleNames = roles.Select(r => r.Name).ToList();
            return roleNames;
        }
        public async Task<ApplicationUserDto?> GetUserByIdAsync(string userId)
        {
            var user = await _repository.User.GetUserByIdAsync(userId, trackChanges: false);
            if (user == null)
                return null;

            return _mapper.Map<ApplicationUserDto>(user);
        }
    }
}
