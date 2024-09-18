using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Exam
    {
        [Key]
        public int ExamID { get; set; }

        [Required(ErrorMessage = "Exam name is required.")]
        public string ExamName { get; set; }

        [Required(ErrorMessage = "Exam date is required.")]
        public DateTime ExamDate { get; set; }

        public TimeSpan Duration { get; set; }

        public string? Description { get; set; }

        // Relationships

        [ForeignKey(nameof(Subject))]
        public int SubjectID { get; set; }
        public Subject Subject { get; set; }

        public ICollection<Grade> Grades { get; set; }
    }
}
