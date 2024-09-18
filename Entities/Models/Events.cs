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
        public int EventID { get; set; }

        [Required(ErrorMessage = "Event name is required.")]
        public string EventName { get; set; }

        [Required(ErrorMessage = "Event date is required.")]
        public DateTime EventDate { get; set; }

        public string? Description { get; set; } 
    }
}
