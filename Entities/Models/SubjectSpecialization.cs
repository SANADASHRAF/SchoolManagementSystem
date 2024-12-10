using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    // غرضه اسناد المواد للمدرسين فى الترم 
    //هتبقى العلاقة بين المدرس والمادة عن طريق الجدول ده 
    public class SubjectSpecialization
    {
        [Key]
        public int SpecializationID { get; set; }

        [Required(ErrorMessage = "Specialization name is required.")]
        public string SpecializationName { get; set; }

        public string Description { get; set; }
        public DateTime? CreateDate { get; set; } = DateTime.Now;

        // Relationships

        [ForeignKey(nameof(Subject))]
        public int SubjectID { get; set; }
        public Subject Subject { get; set; }

        [ForeignKey(nameof(Teacher))]
        public int TeacherID { get; set; }
        public Teacher Teacher { get; set; }

        [ForeignKey(nameof(AcademicYear))]
        public int AcademicYearID { get; set; }
        public AcademicYear AcademicYear { get; set; }

        [ForeignKey(nameof(Term))]
        public int TermID { get; set; }
        public Term Term { get; set; }

    }
}
