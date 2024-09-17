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
        public string YearName { get; set; }

        // Relationships
        public ICollection<StudentClass> StudentClasses { get; set; }
        public ICollection<Class> Classes { get; set; }
        public ICollection<Term> Terms { get; set; }

        public ICollection<Student> Students { get; set; }
    }
}
