﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class AcademicYear
    {

        [Key]
        public int YearID { get; set; }

        [Required(ErrorMessage = "Year name is required.")]
        public string YearName { get; set; }

        [Required(ErrorMessage = "Start date is required.")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "End date is required.")]
        public DateTime EndDate { get; set; }
        public DateTime? CreateDate { get; set; } =DateTime.Now;

        // Relationships
        public ICollection<StudentClass>? StudentClasses { get; set; }
        public ICollection<Class>? Classes { get; set; }
        public ICollection<Attendance>? Attendances { get; set; }
        public ICollection<Book>? books { get; set; }
        public ICollection<ClassSchedule>? classSchedules { get; set; }
        public ICollection<Exam>? exams { get; set; }
        public ICollection<Homework>? homeworks { get; set; }
        public ICollection<Lesson>? lessons { get; set; }
        public ICollection<Subject>? subjects { get; set; }
        public ICollection<SubjectSpecialization>? subjectSpecializations { get; set; }
        public ICollection<StudentExactYear>? studentExactYears { get; set; }


    }
}
