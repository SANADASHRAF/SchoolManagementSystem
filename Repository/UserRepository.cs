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

        public UserRepository(RepositoryContext repositoryContext, RoleManager<IdentityRole> roleManager)
        : base(repositoryContext)
        {
            _roleManager = roleManager;
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

    }
}
