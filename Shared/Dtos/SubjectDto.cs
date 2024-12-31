using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dtos
{

    public record SubjectDto
    {
        public int SubjectID { get; set; }
        public string SubjectName { get; set; }
        public string? Description { get; set; }
        public DateTime? CreateDate { get; set; }
        public int DepartmentID { get; set; }
        public int AcademicYearID { get; set; }
        public int TermID { get; set; }
    }

    public record SubjectForCreationDto
    {
        public string SubjectName { get; set; }
        public string? Description { get; set; }
        public int DepartmentID { get; set; }
        public int AcademicYearID { get; set; }
        public int TermID { get; set; }
    }

    public record SubjectForUpdateDto
    {
        public string SubjectName { get; set; }
        public string? Description { get; set; }
        public int DepartmentID { get; set; }
        public int AcademicYearID { get; set; }
        public int TermID { get; set; }
    }
}
