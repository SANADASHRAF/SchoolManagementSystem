using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Attendance
    {
        [Key]
        public int AttendanceID { get; set; }
        public DateTime Date { get; set; }
        public bool IsPresent { get; set; }

        // Relationships
        [ForeignKey(nameof(Student))]
        public string StudentID { get; set; }
        public Student Student { get; set; }
    }
}
