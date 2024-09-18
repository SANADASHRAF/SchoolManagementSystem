using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Admin
    {
        [Key]
        public int AdminID { get; set; }


        // Relationships

        [ForeignKey(nameof(User))]
        public string? UserID { get; set; }
        public ApplicationUser? User { get; set; }
    }
}
