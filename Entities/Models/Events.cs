using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Events
    {
        [Key]
        public long EventID { get; set; }

        [Required(ErrorMessage = "Event name is required.")]
        public string EventName { get; set; }

        [Required(ErrorMessage = "Event date is required.")]
        public DateTime EventDate { get; set; }
        public string? Description { get; set; }
        public DateTime? CreateDate { get; set; } = DateTime.Now;

        public ICollection<EventsImage> EventsImages { get; set; }
        public ICollection<EventVideo> Videos { get; set; }

    }
}
