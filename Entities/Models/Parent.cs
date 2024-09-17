using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Parent
    {
        [Key]
        public int ParentID { get; set; }

        [ForeignKey(nameof(User))]
        public string UserID { get; set; }
        public ApplicationUser User { get; set; }

        // Relationships
        public ICollection<Student> Children { get; set; }
    }
}
