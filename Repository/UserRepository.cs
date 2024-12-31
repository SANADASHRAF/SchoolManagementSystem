using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Repository
{
    public class UserRepository : RepositoryBase<ApplicationUser>, IUserRepository
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public UserRepository(RepositoryContext repositoryContext, RoleManager<IdentityRole> roleManager
            , UserManager<ApplicationUser> userManager)
        : base(repositoryContext)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task<bool> ValidateRolesAsync(ICollection<string>? roles)
        {
            if (roles == null || !roles.Any())
                return false;

            foreach (var role in roles)
            {
                var roleExists = await _roleManager.RoleExistsAsync(role);
                if (!roleExists)
                    return false;
            }
            return true;
        }

        public async Task<ApplicationUser?> GetUserByIdAsync(string userId, bool trackChanges)
        {
            return await FindByCondition(user => user.Id == userId, trackChanges)
                .Include(u => u.City)
                .Include(u => u.ApplicationUserImage)
                .FirstOrDefaultAsync();
        }

        public async Task<bool> DeleteRoleToUserAsync(string userId, string role)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                return false;

            var isInRole = await _userManager.IsInRoleAsync(user, role);
            if (isInRole)
            {
                var result = await _userManager.RemoveFromRoleAsync(user, role);
                return  true;
            }

            return false; 
        }
    }
}
