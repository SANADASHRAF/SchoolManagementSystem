using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dtos
{
    public class SubjectTermDto
    {
        public int SubjectTermID { get; set; }
        public int SubjectID { get; set; }
        public int TermID { get; set; }
        public int AcademicYearID { get; set; }
    }

    public class SubjectTermForCreationDto
    {
        public int SubjectID { get; set; }
        public int TermID { get; set; }
        public int AcademicYearID { get; set; }
    }

    public class SubjectTermForUpdateDto
    {
        public int TermID { get; set; }
        public int AcademicYearID { get; set; }
    }
}
