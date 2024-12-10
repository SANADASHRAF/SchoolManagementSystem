using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Library
    {
        [Key]
        public int LibraryID { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? CreateDate { get; set; } = DateTime.Now;

        [ForeignKey(nameof(Book))]
        public long BookID { get; set; }
        public Book Book { get; set; }

    }
}
