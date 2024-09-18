using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class StudentClass
    {
        [Key]
        public int StudentClassID { get; set; }

        // Relationships

        [ForeignKey(nameof(Student))]
        public int StudentID { get; set; }
        public Student Student { get; set; }

        [ForeignKey(nameof(Class))]
        public int ClassID { get; set; }
        public Class Class { get; set; }

        [ForeignKey(nameof(Year))]
        public int YearID { get; set; }
        public AcademicYear Year { get; set; }
    }
}
