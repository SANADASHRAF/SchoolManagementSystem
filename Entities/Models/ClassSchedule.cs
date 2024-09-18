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

        // Relationships

        [ForeignKey(nameof(Class))]
        public int ClassID { get; set; }
        public Class Class { get; set; }


        [ForeignKey(nameof(Subject))]
        public int SubjectID { get; set; }
        public Subject Subject { get; set; }


        [ForeignKey(nameof(Teacher))]
        public int TeacherID { get; set; }
        public Teacher Teacher { get; set; }
    }
}
