using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class AcademicYear
    {

        [Key]
        public int YearID { get; set; }

        [Required(ErrorMessage = "Year name is required.")]
        public string YearName { get; set; }

        [Required(ErrorMessage = "Start date is required.")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "End date is required.")]
        public DateTime EndDate { get; set; }

        // Relationships
        public ICollection<StudentClass>? StudentClasses { get; set; }
        public ICollection<Class>? Classes { get; set; }

    }
}
