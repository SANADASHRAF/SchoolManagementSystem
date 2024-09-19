using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class City
    {

        [Key]
        public int CityID { get; set; }

        [Required(ErrorMessage = "City name is required.")]
        public string CityName { get; set; }

        // Relationships
        public ICollection<ApplicationUser> ApplicationUsers { get; set; }

    }
}
