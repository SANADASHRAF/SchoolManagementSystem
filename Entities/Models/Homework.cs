using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Homework
    {
        [Key]
        public int HomeworkID { get; set; }

        [Required(ErrorMessage = "Homework description is required.")]
        public string HomeworkDescription { get; set; }

        [Required(ErrorMessage = "Due date is required.")]
        public DateTime DueDate { get; set; }

        public string? HomeworkUrlFilePath { get; set; }
        public string? HomeworkUrlImagPath { get; set; }

        // Relationships

        [ForeignKey(nameof(Teacher))]
        public int TeacherID { get; set; }
        public Teacher Teacher { get; set; }

        public ICollection<HomeworkSubmission> Submissions { get; set; }
    }
}
