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
        public int ImageID { get; set; }

        [Required(ErrorMessage = "URL is required.")]
        public string ImageUrl { get; set; }
        
        public string? ImageDescription { get; set; }

        // Relationships

        [ForeignKey(nameof(Lesson))]
        public int LessonID { get; set; }
        public Lesson Lesson { get; set; }
    }
}
