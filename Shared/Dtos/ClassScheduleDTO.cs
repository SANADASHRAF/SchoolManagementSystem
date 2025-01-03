using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dtos
{
    public record ClassScheduleForCreationDto
    {
        public DayOfWeek DayOfWeek { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public int ClassroomID { get; set; }
        public int SubjectID { get; set; }
        public int AcademicYearID { get; set; }
        public int TermID { get; set; }
        public int TeacherID { get; set; }
    }

    public record ClassScheduleForUpdateDto
    {
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
    }

    public record ClassScheduleDto
    {
        public int ScheduleID { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public string ClassroomName { get; set; }
        public string SubjectName { get; set; }
        public string TeacherName { get; set; }
    }

}
