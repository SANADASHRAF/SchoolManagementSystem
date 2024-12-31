using Microsoft.AspNetCore.Identity;
using Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IUserService
    {
        Task<IdentityResult> RegisterUser(UserForRegistrationDto userForRegistration);
        Task<bool> ValidateUser(UserForAuthenticationDto userForAuth);
        Task<string> CreateToken();
        Task<bool> AssignRoleToUserAsync(string userName, string role);
        Task<bool> DeleteRoleToUserAsync(string userId, string role);
        Task<bool> ChangePasswordAsync(string userName, string oldPassword, string newPassword);

        //
        Task<string> SoftDeleteUser(string userId);
        Task<string> LogedOut(string userId);

        //


        Task<ApplicationUserDto?> GetUserByIdAsync(string userId);
        Task<List<string>> GetAppRoles();
    }
}
