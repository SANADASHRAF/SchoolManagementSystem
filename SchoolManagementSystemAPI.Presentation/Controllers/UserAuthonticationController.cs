using Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystemAPI.Presentation.Controllers
{
    [Route("SchoolManagement/UserAuthentiaction/[action]")]
    [ApiController]
    public class UserAuthonticationController : ControllerBase
    {
        private readonly IServiceManager _service;
        private readonly ILoggerManager _logger;
        public UserAuthonticationController(IServiceManager service , ILoggerManager logger) 
        {
            _service = service;
            _logger = logger;
        } 

        [HttpPost (Name = "RegisterUser")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> RegisterUser([FromBody] UserForRegistrationDto userForRegistration)
        {
            try
            {
                var result = await _service.userService.RegisterUser(userForRegistration);
                if(result==null)
                    return NotFound("You Must Enter Valid Roles!");

                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.TryAddModelError(error.Code, error.Description);
                    }
                    return BadRequest(ModelState);
                }
                return Ok("User Created Successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(RegisterUser)} service method {ex.Message}");
                throw;
            }

        }


        [HttpPost(Name ="login")]
        public async Task<IActionResult> login([FromBody] UserForAuthenticationDto user)
        {
            try
            {
                if (!await _service.userService.ValidateUser(user))
                    return Unauthorized();

                return Ok(new { Token = await _service.userService.CreateToken() });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }


        [HttpPost(Name ="AssignRole")]
        public async Task<IActionResult> AssignRole([FromBody] AssignRoleDto assignRoleDto)
        {
            var result = await _service.userService.AssignRoleToUserAsync(assignRoleDto.UserName, assignRoleDto.Role);
            if (!result)
            {
                return BadRequest("Failed to assign role.");
            }

            return Ok(new { message = $"Role {assignRoleDto.Role} successfully assigned to {assignRoleDto.UserName}." });
        }


        [HttpPost(Name = "ChangePassword")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordDto changePasswordDto)
        {
            var result = await _service.userService.ChangePasswordAsync(changePasswordDto.UserName, changePasswordDto.OldPassword, changePasswordDto.NewPassword);
            if (!result)
                return BadRequest(new { message = "Failed to change password." });
           

            return Ok(new { message = "Password changed successfully." });
        }


    }
}
