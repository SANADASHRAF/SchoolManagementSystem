using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        //[Required(ErrorMessage = "Image is required")]
        //public long? ApplicationUserImageID { get; set; }

        [Required(ErrorMessage = "Username is required")]
        public string? UserName { get; init; }

        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; init; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string? Email { get; init; }

        [Required(ErrorMessage = "PhoneNumber is required")]
        [RegularExpression(@"^0\d{10}$", ErrorMessage = "Phone number must start with 0 and contain exactly 11 digits.")]
        public string? PhoneNumber { get; init; }

        public ICollection<string>? Roles { get; init; }
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
        [Required]
        public string UserName { get; set; }

        [Required]
        public string OldPassword { get; set; }

        [Required]
        public string NewPassword { get; set; }
    }

}
