using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Attendance
    {



        // Relationships
        [ForeignKey(nameof(Student))]
        public string StudentID { get; set; }
        public Student Student { get; set; }
    }
}
