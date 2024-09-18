using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Video
    {
        [Key]
        public int VideoID { get; set; }
        public string VideoTitle { get; set; }
        public string VideoUrl { get; set; }

        // Relationships

        [ForeignKey(nameof(Lesson))]
        public int LessonID { get; set; }
        public Lesson Lesson { get; set; }
    }
}
