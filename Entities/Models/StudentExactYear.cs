using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
   public class StudentExactYear
    {
        [Key]
        public long StudentExactYearId { get; set; }
        public DateTime? CreateDate { get; set; } = DateTime.Now;

        [ForeignKey(nameof(Student))]
        public int StudentID { get; set; }
        public Student Student { get; set; }

        [ForeignKey(nameof(AcademicYear))]
        public int AcademicYearID { get; set; }
        public AcademicYear AcademicYear { get; set; }
    }
}
