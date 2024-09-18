using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Term
    {
        [Key]
        public int TermID { get; set; }

        [Required(ErrorMessage = "Term name is required.")]
        public string TermName { get; set; }

        [Required(ErrorMessage = "Start date is required.")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "End date is required.")]
        public DateTime EndDate { get; set; }

        // Relationships
        public ICollection<AcademicYear> AcademicYears { get; set; }
        public ICollection<Exam> Exams { get; set; }




    }
}
