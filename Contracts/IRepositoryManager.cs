using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IRepositoryManager
    {
        IAdminRepository Admin {  get; }   
        IAcademicYearRepository AcademicYear {  get; }   
        IAttendanceRepository Attendance {  get; }   
        IBookRepository Book {  get; }   
        ICityRepository City {  get; }   
        IClassRepository Class {  get; }   
        IClassScheduleRepository ClassSchedule {  get; }   
        IDepartmentRepository Department {  get; }   
        IEventsRepository Events {  get; }   
        IExamRepository Exam {  get; }   
        IExamSubmissionRepository ExamSubmission {  get; }   
        IGradeRepository Grade {  get; }   
        IHomeworkRepository Homework {  get; }   
        IHomeworkSubmissionRepository HomeworkSubmission {  get; }   
        IImageRepository Image {  get; }   
        ILessonRepository Lesson {  get; }   
        ILibraryRepository Library {  get; }   
        IParentRepository Parent {  get; }   
        IStudentClassRepository StudentClass {  get; }   
        IStudentRepository Student {  get; }   
        ISubjectRepository Subject {  get; }   
        ISubjectSpecializationRepository SubjectSpecialization {  get; }   
        ISuperAdminRepository SuperAdmin {  get; }   
        ITeacherRepository Teacher {  get; }   
        ITermRepository Term {  get; }
        IUserRepository User { get; }
        IVideoRepository Video {  get; }
        IStudentExactYearRepository  StudentExactYear {  get; }
        ISubjectTermRepository SubjectTerm {  get; }
        void Save();

    }
}
