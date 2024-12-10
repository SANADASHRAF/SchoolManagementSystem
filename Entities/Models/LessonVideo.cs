using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class LessonVideo
    {
        [Key]
        public long LessonVideoId { get; set; }
        public DateTime? CreateDate { get; set; }= DateTime.Now;

        // relationships

        [ForeignKey(nameof(Lesson))]
        public int LessonId { get; set; }
        public Lesson Lesson { get; set; }

        [ForeignKey(nameof(Video))]
        public long VideoId { get; set; }
        public Video Video { get; set; }
    }
}
