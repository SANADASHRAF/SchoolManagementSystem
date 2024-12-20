﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class TuitionPayments
    {
        [Key]
        public int PaymentID { get; set; }
        [Required]
        public DateTime PaymentDate { get; set; }
        public decimal Amount { get; set; }
        public DateTime? CreateDate { get; set; } = DateTime.Now;

        // Relationships
        [ForeignKey(nameof(Student))]
        public int StudentID { get; set; }
        public Student Student { get; set; }
    }
}
