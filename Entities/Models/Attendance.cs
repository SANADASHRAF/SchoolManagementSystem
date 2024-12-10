using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Attendance
    {
        [Key]
        public int AttendanceID { get; set; }

        [Required(ErrorMessage = "Date is required.")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "IsPresent is required.")]
        public bool IsPresent { get; set; }
        public DateTime? CreateDate { get; set; } = DateTime.Now;

        // Relationships

        [ForeignKey(nameof(Student))]
        public int StudentID { get; set; }
        public Student Student { get; set; }

    
        [ForeignKey(nameof(AcademicYear))]
        public int AcademicYearID { get; set; }
        public AcademicYear AcademicYear { get; set; }

        [ForeignKey(nameof(Term))]
        public int TermID { get; set; }
        public Term Term { get; set; }

        [ForeignKey(nameof(Teacher))]
        public int TeacherID { get; set; }
        public Teacher Teacher { get; set; }
    }
}
