using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IUserRepository
    {
        Task<bool> ValidateRolesAsync(ICollection<string>? roles);
        Task<ApplicationUser?> GetUserByIdAsync(string userId, bool trackChanges);
    }
}
