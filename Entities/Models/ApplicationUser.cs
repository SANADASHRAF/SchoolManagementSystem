using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Date of birth is required.")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Gender is required.")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Enrollment date is required.")]
        public DateTime EnrollmentDate { get; set; }=DateTime.Now;
        public bool IsDeleted { get; set; }=false;
        public string? Token { get; set; }

        // Relationships

        [ForeignKey(nameof(City))]
        public int? CityID { get; set; }
        public City? City { get; set; }


        [ForeignKey(nameof(ApplicationUserImage))]
        public long? ApplicationUserImageID { get; set; }
        public ApplicationUserImage? ApplicationUserImage { get; set; }


    }
}
