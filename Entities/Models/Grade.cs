using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Grade
    {

        [Key]
        public int GradeID { get; set; }

        [Required(ErrorMessage = "Grade value is required.")]
        [Range(0, 100, ErrorMessage = "Grade must be between 0 and 100.")]
        public double Value { get; set; }

        public string? Comments { get; set; }
        public DateTime? CreateDate { get; set; } = DateTime.Now;

        // Relationships

        [ForeignKey(nameof(Exam))]
        public int ExamID { get; set; }
        public Exam Exam { get; set; }

        [ForeignKey(nameof(Student))]
        public int StudentID { get; set; }
        public Student Student { get; set; }

    }
}
