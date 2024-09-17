using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class ApplicationUser : IdentityUser 
    {
        
        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Address { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }
       
        [Required]
        public string? Gender { get; set; }

        [Required]
        public DateTime EnrollmentDate { get; set; }

    }
}
