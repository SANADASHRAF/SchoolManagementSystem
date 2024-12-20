﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Student
    {
        [Key]
        public int StudentID { get; set; }
        public DateTime? CreateDate { get; set; } = DateTime.Now;

        // Relationships
        [ForeignKey (nameof (User))]
        public string UserID { get; set; }
        public ApplicationUser User { get; set; }

        [ForeignKey(nameof(Department))]
        public int DepartmentID { get; set; }
        public Department Department { get; set; }

        // Optional 
        [ForeignKey(nameof(Parent))]
        public int? ParentID { get; set; }
        public Parent? Parent { get; set; }

        [ForeignKey(nameof(StudentExactYear))]
        public int? StudentExactYearID { get; set; }
        public StudentExactYear? studentExactYear { get; set; }

        //public ICollection<Lesson> Lessons { get; set; }
        public ICollection<HomeworkSubmission> HomeworkSubmissions { get; set; }
        public ICollection<Attendance> Attendances { get; set; }
        public ICollection<Grade> Grades { get; set; }
        public ICollection<StudentClass> StudentClasses { get; set; }
        public ICollection<ExamSubmission> ExamSubmissions { get; set; }
    }
}
