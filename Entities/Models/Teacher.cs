using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Teacher
    {
        [Key]
        public int TeacherID { get; set; }
        public DateTime? CreateDate { get; set; } = DateTime.Now;

         // Relationships

        [ForeignKey(nameof(User))]
        public string UserID { get; set; }
        public ApplicationUser User { get; set; }

       

        public ICollection<ClassSchedule> ClassSchedules { get; set; }
        public ICollection<Exam> exams { get; set; }
        public ICollection<Homework> homeworks { get; set; }
        public ICollection<Attendance>? Attendances { get; set; }
        public ICollection<SubjectSpecialization>? subjectSpecializations { get; set; }
    }
}
