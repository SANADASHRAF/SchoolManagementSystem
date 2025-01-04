using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dtos
{
    public record StudentDto
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
    }

    public record StudentClassForCreationDto
    {
        public int StudentID { get; set; }
        public int ClassroomID { get; set; }
        public int YearID { get; set; }
    }
}
