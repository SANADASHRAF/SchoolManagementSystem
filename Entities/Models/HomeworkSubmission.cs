using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class HomeworkSubmission
    {
        [Key]
        public int HomeworkSubmissionID { get; set; }

        [Required(ErrorMessage = "Submission date is required.")]
        public DateTime SubmissionDate { get; set; }

        public string? Comments { get; set; }

        public string? HomeworkSubmissionUrlFilePath { get; set; }
        public string? HomeworkSubmissionUrlImagPath { get; set; }
        public DateTime? CreateDate { get; set; } = DateTime.Now;

        [ForeignKey(nameof(Homework))]
        public int HomeworkID { get; set; }
        public Homework Homework { get; set; }


        [ForeignKey(nameof(Student))]
        public int StudentID { get; set; }
        public Student Student { get; set; }
    }
}
