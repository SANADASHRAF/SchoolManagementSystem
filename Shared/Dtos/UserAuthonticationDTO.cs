using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dtos
{

    public record UserForRegistrationDto
    {
        [Required(ErrorMessage = "Name is required")]
        public string? Name { get; init; }

        [Required(ErrorMessage = "Address is required")]
        public string? Address { get; init; }

        [Required(ErrorMessage = "DateOfBirth is required")]
        public DateTime DateOfBirth { get; init; }

        [Required(ErrorMessage = "Gender is required")]
        public string? Gender { get; init; }

        [Required(ErrorMessage = "City is required")]
        public int CityID { get; set; }

        [Required(ErrorMessage = "Username is required")]
        public string? UserName { get; init; }

        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; init; }

        [NotMapped]
        [Compare("Password" , ErrorMessage ="password not match")]
        [Required(ErrorMessage = "Password is required")]
        public string? ConfirmPassword { get; init; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string? Email { get; init; }

        [Required(ErrorMessage = "PhoneNumber is required")]
        [RegularExpression(@"^0\d{10}$", ErrorMessage = "Phone number must start with 0 and contain exactly 11 digits.")]
        public string? PhoneNumber { get; init; }

        public ICollection<string>? Roles { get; init; }
    }

    public record UserImageDto
    {
        public string Id { get; set; }
        [Required(ErrorMessage = "An image file is required.")]
        [DataType(DataType.Upload)]
        public IFormFile? Image { get; init; }
    }
    public record UserForAuthenticationDto
    {
        [Required(ErrorMessage = "User name is required")]
        public string? UserName { get; init; }
        [Required(ErrorMessage = "Password name is required")]
        public string? Password { get; init; }
    }

    public record AssignRoleDto
    {
        [Required(ErrorMessage = "UserName is required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Role is required")]
        public string Role { get; set; }
    }

    public record ChangePasswordDto
    {
        [Required(ErrorMessage = "UserName is required")]
        public string UserName { get; set; }

        [MinLength(10,ErrorMessage ="length must be greater that or equal 10 char")]
        [Required (ErrorMessage = "OldPassword is required")]
        public string OldPassword { get; set; }

        [MinLength(10, ErrorMessage = "length must be greater that or equal 10 char")]
        [Required(ErrorMessage = "NewPassword is required")]
        public string NewPassword { get; set; }
        [NotMapped]
        [Compare("NewPassword" , ErrorMessage ="password not match!")]
        public string ConfirmNewPassword { get; set; }
    }


    public class ApplicationUserDto
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public string? CityName { get; set; }
        public string? ImageUrl { get; set; }
        public string? Token { get; set; }
        public List<string>? Role { get; set; }
    }

}
