using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryContext : IdentityDbContext<ApplicationUser>
    {
        public RepositoryContext(DbContextOptions options)
        : base(options)
        { }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Parent> Parents { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<SuperAdmin> SuperAdmins { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<SubjectSpecialization> SubjectSpecializations { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<ClassSchedule> ClassSchedules { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Homework> Homeworks { get; set; }
        public DbSet<HomeworkSubmission> HomeworkSubmissions { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<ExamSubmission> ExamSubmissions { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Video> Videos { get; set; }
        public DbSet<Library> Libraries { get; set; }
        public DbSet<Events> Events { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<AcademicYear> AcademicYears { get; set; }
        public DbSet<StudentClass> StudentClasses { get; set; }
        public DbSet<Term> Terms { get; set; }
        public DbSet<TuitionPayments> TuitionPayments { get; set; }
        public DbSet<EventVideo> eventVideos { get; set; }
        public DbSet<EventsImage> eventsImages { get; set; }
        public DbSet<LessonImage> lessonImages { get; set; }
        public DbSet<LessonVideo> lessonVideos { get; set; }
        public DbSet<Book> books { get; set; }
        public DbSet<ApplicationUserImage> applicationUserImages { get; set; }
        public DbSet<StudentExactYear> studentExactYears { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Apply 'Restrict' behavior to all relationships by default
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var foreignKey in entityType.GetForeignKeys())
                {
                    foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
                }
            }
        }

    }
}
