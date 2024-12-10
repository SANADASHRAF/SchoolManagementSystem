using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class ApplicationUserImage
    {
        [Key]
        public long ApplicationUserImageId { get; set; }
        public DateTime? CreateDate { get; set; }= DateTime.Now;

        // relationships

        [ForeignKey(nameof(User))]
        public string UserID { get; set; }
        public ApplicationUser User { get; set; }

        [ForeignKey(nameof(Image))]
        public long ImageId { get; set; }
        public Image Image { get; set; }
    }
}
