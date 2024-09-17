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
        public string TermName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }


        [ForeignKey(nameof(Year))]
        public int YearID { get; set; }
        public AcademicYear Year { get; set; }

        public ICollection<Student> Students { get; set; }
    }
}
