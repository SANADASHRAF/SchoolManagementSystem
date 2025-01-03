using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class ClassSchedule
    {
        [Key]
        public int ScheduleID { get; set; }

        [Required(ErrorMessage = "Day Of Week is required.")]
        public DayOfWeek DayOfWeek { get; set; }

        [Required(ErrorMessage = "StartTime date is required.")]
        public TimeSpan StartTime { get; set; }


        [Required(ErrorMessage = "EndTime date is required.")]
        public TimeSpan EndTime { get; set; }
        public DateTime? CreateDate { get; set; } = DateTime.Now;

        // Relationships

        [ForeignKey(nameof(Day))]
        public int DayID { get; set; }
        public Day Day { get; set; }

        [ForeignKey(nameof(Classroom))]
        public int ClassroomID { get; set; }
        public Classroom Classroom { get; set; }


        [ForeignKey(nameof(Subject))]
        public int SubjectID { get; set; }
        public Subject Subject { get; set; }

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
