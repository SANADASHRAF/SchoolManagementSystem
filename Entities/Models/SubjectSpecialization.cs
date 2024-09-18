using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class SubjectSpecialization
    {
        [Key]
        public int SpecializationID { get; set; }

        [Required(ErrorMessage = "Specialization name is required.")]
        public string SpecializationName { get; set; }

        public string Description { get; set; }

        // Relationships
        [ForeignKey(nameof(Subject))]
        public int SubjectID { get; set; }
        public Subject Subject { get; set; }
    }
}
