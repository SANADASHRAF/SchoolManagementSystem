using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class ExamSubmission
    {
        [Key]
        public int ExamSubmissionID { get; set; }

        [Required(ErrorMessage = "Submission date is required.")]
        public DateTime SubmissionDate { get; set; }

        // Relationships

        [ForeignKey(nameof(Exam))]
        public int ExamID { get; set; }
        public Exam Exam { get; set; }


        [ForeignKey(nameof(Student))]
        public int StudentID { get; set; }
        public Student Student { get; set; }


    }
}
