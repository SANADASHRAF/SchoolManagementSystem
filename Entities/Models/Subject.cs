using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Subject
    {
        [Key]
        public int SubjectID { get; set; }

        [Required(ErrorMessage = "Subject name is required.")]
        public string SubjectName { get; set; }

        public string? Description { get; set; }
        public DateTime? CreateDate { get; set; } = DateTime.Now;

        // Relationships

        [ForeignKey(nameof(Department))]
        public int DepartmentID { get; set; }
        public Department Department { get; set; }

        public ICollection<Lesson> Lessons { get; set; }
        public ICollection<Class> Classes { get; set; }
        public ICollection<SubjectTerm> SubjectTerms { get; set; }
    }
}
