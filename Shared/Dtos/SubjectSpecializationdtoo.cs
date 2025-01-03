using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dtos
{
    public record SubjectSpecializationDto
    {
        public int SpecializationID { get; set; }
        public string SpecializationName { get; set; }
        public string Description { get; set; }
        public DateTime? CreateDate { get; set; }
        public int SubjectID { get; set; }
        public string SubjectName { get; set; }
        public int TeacherID { get; set; }
        public string TeacherName { get; set; }
    }

    public record SubjectSpecializationForCreationDto
    {
        [Required(ErrorMessage = "Specialization name is required.")]
        public string SpecializationName { get; set; }

        public string Description { get; set; }

        [Required(ErrorMessage = "Subject ID is required.")]
        public int SubjectID { get; set; }

        [Required(ErrorMessage = "Teacher ID is required.")]
        public int TeacherID { get; set; }
    }

    public record TeacherSubjectDto
    {
        public string TeacherName { get; set; }
        public List<string> Subjects { get; set; }
    }

}
