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
        public string ClassName { get; set; }

        // Relationships

        [ForeignKey(nameof(Year))]
        public int YearID { get; set; }
        public AcademicYear Year { get; set; }
   
        public ICollection<StudentClass> StudentClasses { get; set; }
        //public ICollection<Subject> Subjects { get; set; }
        //public ICollection<ClassSchedule> Schedules { get; set; }
    }
}
