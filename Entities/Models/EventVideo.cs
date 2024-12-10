using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class EventVideo
    {
        [Key]
        public long EventVideoId { get; set; }
        public DateTime? CreateDate { get; set; }= DateTime.Now;

        // relationships

        [ForeignKey(nameof(Events))]
        public long EventId { get; set; }
        public Events Events { get; set; }

        [ForeignKey(nameof(Video))]
        public long VideoID { get; set; }
        public Video Video { get; set; }
    }
}
