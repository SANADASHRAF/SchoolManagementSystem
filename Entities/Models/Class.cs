using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Class
    {
        [Key]
        public int ClassID { get; set; }

        [Required(ErrorMessage = "Class name is required.")]
        public string ClassName { get; set; }

        public string Description { get; set; } 

        // Relationships

        [ForeignKey(nameof(Year))]
        [Required(ErrorMessage = "Year ID is required.")]
        public int YearID { get; set; }
        public AcademicYear Year { get; set; }

        public ICollection<StudentClass> StudentClasses { get; set; }
        public ICollection<Subject> Subjects { get; set; }
        public ICollection<ClassSchedule> Schedules { get; set; }
    }
}
