using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class SubjectTerm
    {
        [Key]
        public int SubjectTermID { get; set; }

        [ForeignKey(nameof(Subject))]
        public int SubjectID { get; set; }
        public Subject? Subject { get; set; }

        [ForeignKey(nameof(Term))]
        public int TermID { get; set; }
        public Term? Term { get; set; }

        [ForeignKey(nameof(AcademicYear))]
        public int AcademicYearID { get; set; }
        public AcademicYear? AcademicYear { get; set; }
    }
}
