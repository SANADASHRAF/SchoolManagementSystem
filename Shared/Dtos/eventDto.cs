using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dtos
{
    public record EventForCreationDto
    {
        [Required(ErrorMessage = "Event name is required.")]
        public string EventName { get; set; }

        [Required(ErrorMessage = "Event date is required.")]
        public DateTime EventDate { get; set; }
        public string? Description { get; set; }
    }

    public record EventDto
    {
        public long EventID { get; set; }
        public string EventName { get; set; }
        public DateTime EventDate { get; set; }
        public string? Description { get; set; }
        public ICollection<string>? Images { get; set; } 
        public ICollection<string>? Videos { get; set; } 
    }
}
