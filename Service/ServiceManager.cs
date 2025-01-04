using AutoMapper;
using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Repository;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IAcademicYearService> _academicYear;
        private readonly Lazy<IAdminService> _adminService;
        private readonly Lazy<IAttendanceService> _attendanceService;
        private readonly Lazy<IBookService> _bookService;
        private readonly Lazy<ICityService> _cityService;
        private readonly Lazy<IClassScheduleService> _classScheduleService;
        private readonly Lazy<IClassService> _classService;
        private readonly Lazy<IDepartmentService> _departmentService ;
        private readonly Lazy<IEventsService>  _eventsService ;
        private readonly Lazy<IExamService> _examService ;
        private readonly Lazy<IExamSubmissionService> _examSubmissionService ;
        private readonly Lazy<IGradeService> _gradeService ;
        private readonly Lazy<IHomeworkService> _homeworkService ;
        private readonly Lazy<IHomeworkSubmissionService> _homeworkSubmissionService ;
        private readonly Lazy<IImageService> _imageService ;
        private readonly Lazy<ILessonService> _lessonService;
        private readonly Lazy<IParentService> _parentService;
        private readonly Lazy<IStudentClassService> _studentClassService;
        private readonly Lazy<IStudentExactYearService> _studentExactYearService;
        private readonly Lazy<ISubjectSpecializationService> _subjectSpecializationService;
        private readonly Lazy<IStudentService> _studentService ;
        private readonly Lazy<ISubjectService> _subjectService ;
        private readonly Lazy<ISuperAdminService> _superAdminService;
        private readonly Lazy<ITeacherService> _teacherService;
        private readonly Lazy<ITermService> _termService;
        private readonly Lazy<IUserService> _userService;
        private readonly Lazy<IVideoService> _videoService ;
        private readonly Lazy<ISubjectTermService> _subjectTermService;
        private readonly Lazy<IConstantService> _constantService;

   

        public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager logger ,
                              IMapper mapper, UserManager<ApplicationUser> userManager, IConfiguration configuration,
                              RoleManager<IdentityRole> roleManager, RepositoryContext repository)
        {
            _academicYear = new Lazy<IAcademicYearService>(() => new AcademicYearService(repositoryManager, logger));
            _adminService = new Lazy<IAdminService>(() => new AdminService(repositoryManager, logger));
            _attendanceService = new Lazy<IAttendanceService>(() => new AttendanceService(repositoryManager, logger));
            _bookService = new Lazy<IBookService>(() => new BookService(repositoryManager, logger,mapper));
            _cityService = new Lazy<ICityService>(() => new CityService(repositoryManager, logger));
            _classScheduleService = new Lazy<IClassScheduleService>(() => new ClassScheduleService(repositoryManager, logger,mapper));
            _classService = new Lazy<IClassService>(() => new ClassService(repositoryManager, logger));
            _departmentService = new Lazy<IDepartmentService>(() => new DepartmentService(repositoryManager, logger));
            _eventsService = new Lazy<IEventsService>(() => new EventsService(repositoryManager,mapper, logger));
            _examService = new Lazy<IExamService>(() => new ExamService(repositoryManager, logger));
            _examSubmissionService = new Lazy<IExamSubmissionService>(() => new ExamSubmissionService(repositoryManager, logger));
            _gradeService = new Lazy<IGradeService>(() => new GradeService(repositoryManager, logger));
            _homeworkService = new Lazy<IHomeworkService>(() => new HomeworkService(repositoryManager, logger));
            _homeworkSubmissionService = new Lazy<IHomeworkSubmissionService>(() => new HomeworkSubmissionService(repositoryManager, logger));
            _imageService = new Lazy<IImageService>(() => new ImageService(repositoryManager, logger, userManager));
            _lessonService = new Lazy<ILessonService>(() => new LessonService(repositoryManager, logger));
            _parentService = new Lazy<IParentService>(() => new ParentService(repositoryManager, logger));
            _studentClassService = new Lazy<IStudentClassService>(() => new StudentClassService(repositoryManager, logger,mapper));
            _studentExactYearService = new Lazy<IStudentExactYearService>(() => new StudentExactYearService(repositoryManager, logger));
            _subjectSpecializationService = new Lazy<ISubjectSpecializationService>(() => new SubjectSpecializationService(repositoryManager, logger,mapper));
            _studentService = new Lazy<IStudentService>(() => new StudentService(repositoryManager, logger));
            _subjectService = new Lazy<ISubjectService>(() => new SubjectService(repositoryManager, mapper, logger));
            _superAdminService = new Lazy<ISuperAdminService>(() => new SuperAdminService(repositoryManager, logger));
            _teacherService = new Lazy<ITeacherService>(() => new TeacherService(repositoryManager, logger));
            _termService = new Lazy<ITermService>(() => new TermService(repositoryManager, logger));
            _userService = new Lazy<IUserService>(() => new UserService(repositoryManager, logger, mapper, userManager,configuration,roleManager));
            _videoService = new Lazy<IVideoService>(() => new VideoService(repositoryManager, logger));
            _subjectTermService = new Lazy<ISubjectTermService>(() => new SubjectTermService(repositoryManager, mapper, logger));
            _constantService = new Lazy<IConstantService>(() => new ConstantService(mapper,repository));

        }
        public IAcademicYearService AcademicYearService => _academicYear.Value;
        public IAdminService AdminService => _adminService.Value;
        public IAttendanceService AttendanceService => _attendanceService.Value;
        public IBookService bookService => _bookService.Value;
        public ICityService cityService => _cityService.Value;
        public IClassScheduleService classScheduleService => _classScheduleService.Value;
        public IClassService classService => _classService.Value;
        public IDepartmentService departmentService => _departmentService.Value;
        public IEventsService eventsService => _eventsService.Value;
        public IExamService examService => _examService.Value;
        public IExamSubmissionService examSubmissionService => _examSubmissionService.Value;
        public IGradeService gradService => _gradeService.Value;
        public IHomeworkService homeworkService => _homeworkService.Value;
        public IHomeworkSubmissionService homeworkSubmissionService => _homeworkSubmissionService.Value;
        public IImageService imageService => _imageService.Value;
        public ILessonService lessonService => _lessonService.Value;
        public IParentService parentService => _parentService.Value;
        public IStudentClassService studentClassService => _studentClassService.Value;
        public IStudentExactYearService studentExactYearService => _studentExactYearService.Value;
        public ISubjectSpecializationService subjectSpecializationService => _subjectSpecializationService.Value;
        public IStudentService studentService => _studentService.Value;
        public ISubjectService subjectService => _subjectService.Value;
        public ISuperAdminService superAdminService => _superAdminService.Value;
        public ITeacherService teacherService => _teacherService.Value;
        public ITermService termService => _termService.Value;
        public IUserService userService => _userService.Value;
        public IVideoService videoService => _videoService.Value;
        public ISubjectTermService subjectTermService => _subjectTermService.Value;
        public IConstantService constantService => _constantService.Value;

    }
}
