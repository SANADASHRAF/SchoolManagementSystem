using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Teacher
    {
        [Key]
        public int TeacherID { get; set; }

        [ForeignKey(nameof(User))]
        public string UserID { get; set; }
        public ApplicationUser User { get; set; }

        // Relationships
        public ICollection<ClassSchedule> ClassSchedules { get; set; }
        public ICollection<Subject> Subjects { get; set; }
    }
}
