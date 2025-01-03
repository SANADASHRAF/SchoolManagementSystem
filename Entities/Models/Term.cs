using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Term
    {
        [Key]
        public int TermID { get; set; }

        [Required(ErrorMessage = "Term name is required.")]
        public string? TermName { get; set; }

        public DateTime? CreateDate { get; set; } = DateTime.Now;

        // 

        public ICollection<Attendance>? Attendances { get; set; }
        public ICollection<Book>? books { get; set; }
        public ICollection<ClassSchedule>? classSchedules { get; set; }
        public ICollection<Exam>? exams { get; set; }
        public ICollection<Homework>? homeworks { get; set; }
        public ICollection<Lesson>? lessons { get; set; }
        public ICollection<SubjectTerm>? SubjectTerms { get; set; }


    }
}
