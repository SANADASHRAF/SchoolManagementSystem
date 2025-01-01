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
        public long VideoID { get; set; }
        public string? VideoTitle { get; set; }
        public string? VideoDiscription { get; set; }
        public string VideoUrl { get; set; }
        public string VideoName { get; set; }
        public DateTime? CreateDate { get; set; } = DateTime.Now;

        // Relationships

        public ICollection<EventVideo> EventVideos { get; set; }
        public ICollection<LessonVideo> LessonVideos { get; set; }
    }
}
