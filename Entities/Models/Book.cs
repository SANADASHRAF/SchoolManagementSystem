using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Book
    {
        [Key]
        public long BookId { get; set; }

        [Required]
        public string BookFilePath { get; set; }
        public string BookName { get; set; }
        public string BookAuther { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Isdeleted { get; set; }=false;
        public DateTime? CreateDate { get; set; } = DateTime.Now;

        [ForeignKey(nameof(AcademicYear))]
        public int AcademicYearID { get; set; }
        public AcademicYear AcademicYear { get; set; }

        [ForeignKey(nameof(Term))]
        public int TermID { get; set; }
        public Term Term { get; set; }

        [ForeignKey(nameof(Department))]
        public int? DepartmentID { get; set; }
        public Department Department { get; set; }

    }
}
