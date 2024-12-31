using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
   public sealed class RepositoryManager : IRepositoryManager
   {
        public readonly RepositoryContext _repositoryContext;
        public readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;

        private readonly Lazy<IAdminRepository> _adminRepository;
        private readonly Lazy<IAcademicYearRepository> _academicYearRepository;
        private readonly Lazy<IAttendanceRepository> _attendanceRepository;
        private readonly Lazy<IBookRepository> _bookRepository;
        private readonly Lazy<ICityRepository> _cityRepository;
        private readonly Lazy<IClassRepository> _classRepository;
        private readonly Lazy<IClassScheduleRepository> _classScheduleRepository;
        private readonly Lazy<IDepartmentRepository> _departmentRepository;
        private readonly Lazy<IEventsRepository> _eventsRepository;
        private readonly Lazy<IExamRepository> _examRepository;
        private readonly Lazy<IExamSubmissionRepository> _examSubmissionRepository;
        private readonly Lazy<IGradeRepository> _gradeRepository;
        private readonly Lazy<IHomeworkRepository> _homeworkRepository;
        private readonly Lazy<IHomeworkSubmissionRepository> _homeworkSubmissionRepository;
        private readonly Lazy<IImageRepository> _imageRepository;
        private readonly Lazy<ILessonRepository> _lessonRepository;
        private readonly Lazy<ILibraryRepository> _libraryRepository;
        private readonly Lazy<IParentRepository> _parentRepository;
        private readonly Lazy<IStudentClassRepository> _studentClassRepository;
        private readonly Lazy<IStudentRepository> _studentRepository;
        private readonly Lazy<ISubjectRepository> _subjectRepository;
        private readonly Lazy<ISubjectSpecializationRepository> _subjectSpecializationRepository;
        private readonly Lazy<ISuperAdminRepository> _superAdminRepository;
        private readonly Lazy<ITeacherRepository> _teacherRepository;
        private readonly Lazy<ITermRepository> _termRepository;
        private readonly Lazy<IUserRepository> _userRepository;
        private readonly Lazy<IVideoRepository> _videoRepository;
        private readonly Lazy<IStudentExactYearRepository> _studentExactYear ;

        public RepositoryManager(RepositoryContext repositoryContext , RoleManager<IdentityRole> roleManager ,
            UserManager<ApplicationUser> userManager)
        {
            _repositoryContext = repositoryContext;
            _roleManager = roleManager;
            _userManager = userManager;

            _adminRepository = new Lazy<IAdminRepository>(() => new AdminRepository(_repositoryContext));
            _academicYearRepository = new Lazy<IAcademicYearRepository>(() => new AcademicYearRepository(_repositoryContext));
            _attendanceRepository = new Lazy<IAttendanceRepository>(() => new AttendanceRepository(_repositoryContext));
            _bookRepository = new Lazy<IBookRepository>(() => new BookRepository(_repositoryContext));
            _cityRepository = new Lazy<ICityRepository>(() => new CityRepository(_repositoryContext));
            _classRepository = new Lazy<IClassRepository>(() => new ClassRepository(_repositoryContext));
            _classScheduleRepository = new Lazy<IClassScheduleRepository>(() => new ClassScheduleRepository(_repositoryContext));
            _departmentRepository = new Lazy<IDepartmentRepository>(() => new DepartmentRepository(_repositoryContext));
            _eventsRepository = new Lazy<IEventsRepository>(() => new EventsRepository(_repositoryContext));
            _examRepository = new Lazy<IExamRepository>(() => new ExamRepository(_repositoryContext));
            _examSubmissionRepository = new Lazy<IExamSubmissionRepository>(() => new ExamSubmissionRepository(_repositoryContext));
            _gradeRepository = new Lazy<IGradeRepository>(() => new GradeRepository(_repositoryContext));
            _homeworkRepository = new Lazy<IHomeworkRepository>(() => new HomeworkRepository(_repositoryContext));
            _homeworkSubmissionRepository = new Lazy<IHomeworkSubmissionRepository>(() => new HomeworkSubmissionRepository(_repositoryContext));
            _imageRepository = new Lazy<IImageRepository>(() => new ImageRepository(_repositoryContext));
            _lessonRepository = new Lazy<ILessonRepository>(() => new LessonRepository(_repositoryContext));
            _libraryRepository = new Lazy<ILibraryRepository>(() => new LibraryRepository(_repositoryContext));
            _parentRepository = new Lazy<IParentRepository>(() => new ParentRepository(_repositoryContext));
            _studentClassRepository = new Lazy<IStudentClassRepository>(() => new StudentClassRepository(_repositoryContext));
            _studentRepository = new Lazy<IStudentRepository>(() => new StudentRepository(_repositoryContext));
            _subjectRepository = new Lazy<ISubjectRepository>(() => new SubjectRepository(_repositoryContext));
            _subjectSpecializationRepository = new Lazy<ISubjectSpecializationRepository>(() => new SubjectSpecializationRepository(_repositoryContext));
            _superAdminRepository = new Lazy<ISuperAdminRepository>(() => new SuperAdminRepository(_repositoryContext));
            _teacherRepository = new Lazy<ITeacherRepository>(() => new TeacherRepository(_repositoryContext));
            _termRepository = new Lazy<ITermRepository>(() => new TermRepository(_repositoryContext));
            _userRepository = new Lazy<IUserRepository>(() => new UserRepository(_repositoryContext,_roleManager,_userManager));
            _videoRepository = new Lazy<IVideoRepository>(() => new VideoRepository(_repositoryContext));
            _studentExactYear = new Lazy<IStudentExactYearRepository>(() => new StudentExactYearRepository(_repositoryContext));
        }
        
        public IAdminRepository Admin => _adminRepository.Value;
        public IAcademicYearRepository AcademicYear => _academicYearRepository.Value;
        public IAttendanceRepository Attendance => _attendanceRepository.Value;
        public IBookRepository Book => _bookRepository.Value;
        public ICityRepository City => _cityRepository.Value;
        public IClassRepository Class => _classRepository.Value;
        public IClassScheduleRepository ClassSchedule => _classScheduleRepository.Value;
        public IDepartmentRepository Department => _departmentRepository.Value;
        public IEventsRepository Events => _eventsRepository.Value;
        public IExamRepository Exam => _examRepository.Value;
        public IExamSubmissionRepository ExamSubmission => _examSubmissionRepository.Value;
        public IGradeRepository Grade => _gradeRepository.Value;
        public IHomeworkRepository Homework => _homeworkRepository.Value;
        public IHomeworkSubmissionRepository HomeworkSubmission => _homeworkSubmissionRepository.Value;
        public IImageRepository Image => _imageRepository.Value;
        public ILessonRepository Lesson => _lessonRepository.Value;
        public ILibraryRepository Library => _libraryRepository.Value;
        public IParentRepository Parent => _parentRepository.Value;
        public IStudentClassRepository StudentClass => _studentClassRepository.Value;
        public IStudentRepository Student => _studentRepository.Value;
        public ISubjectRepository Subject => _subjectRepository.Value;
        public ISubjectSpecializationRepository SubjectSpecialization => _subjectSpecializationRepository.Value;
        public ISuperAdminRepository SuperAdmin => _superAdminRepository.Value;
        public ITeacherRepository Teacher => _teacherRepository.Value;
        public ITermRepository Term => _termRepository.Value;
        public IUserRepository User => _userRepository.Value;
        public IVideoRepository Video => _videoRepository.Value;
        public IStudentExactYearRepository StudentExactYear => _studentExactYear.Value;

        public void Save() => _repositoryContext.SaveChanges();
    }
}
