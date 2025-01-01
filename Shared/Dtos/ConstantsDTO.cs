using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dtos
{
    public record AcademicYearDto
    {
        public int YearID { get; set; }
        public string AcademicYearName { get; set; }
    }

    public record CityDto
    {
        public int CityID { get; set; }
        public string CityName { get; set; }
    }

    public record ClassPeriodDto
    {
        public int ClassPeriodID { get; set; }
        public string ClassPeriodName { get; set; }
    }

    public record DayDto
    {
        public int DayId { get; set; }
        public string DayeName { get; set; }
    }

    public record TermDto
    {
        public int TermID { get; set; }
        public string TermName { get; set; }
    }

    public record ClassroomDTO
    {
        public int ClassroomID { get; set; }
        public string ClassroomName { get; set; }
        public int NumberOfStudents { get; set; }
        public String AcademicYearName { get; set; }
    }
}
