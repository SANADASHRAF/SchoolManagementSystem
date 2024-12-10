using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class EventsImage
    {
        [Key]
        public long EventsImageId { get; set; }
        public DateTime? CreateDate { get; set; }=DateTime.Now;

        // relationships

        [ForeignKey(nameof(Events))]
        public long EventId { get; set; }
        public Events Events {  get; set; }

        [ForeignKey(nameof(Image))]
        public long ImageId { get; set; }
        public Image Image { get; set; }

    }
}
