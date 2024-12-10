using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Lesson
    {
        [Key]
        public int LessonID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public DateTime? CreateDate { get; set; } = DateTime.Now;

        // Relationships

        [ForeignKey(nameof(Subject))]
        public int SubjectID { get; set; }
        public Subject Subject { get; set; }

        [ForeignKey(nameof(AcademicYear))]
        public int AcademicYearID { get; set; }
        public AcademicYear AcademicYear { get; set; }

        [ForeignKey(nameof(Term))]
        public int TermID { get; set; }
        public Term Term { get; set; }

        public ICollection<LessonImage> LessonImages { get; set; }
        public ICollection<LessonVideo> LessonVideos { get; set; }
    }
}
