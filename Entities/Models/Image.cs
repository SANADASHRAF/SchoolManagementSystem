using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Image
    {
        [Key]
        public long ImageID { get; set; }

        [Required(ErrorMessage = "URL is required.")]
        public string ImageUrl { get; set; }
        
        public string? ImageDescription { get; set; }
        public DateTime? CreateDate { get; set; } = DateTime.Now;

        // Relationships

        public ICollection<EventsImage> EventsImages { get; set; }
        public ICollection<LessonImage> lessonImages { get; set; }

    }
}
