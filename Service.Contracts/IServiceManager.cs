using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IServiceManager
    {
        IAcademicYearService AcademicYearService { get; }
        IAdminService AdminService { get; }
        IAttendanceService AttendanceService { get; }
        IBookService bookService { get; }
        ICityService cityService { get; }
        IClassService classService { get; }
        IClassScheduleService classScheduleService { get; }
        IDepartmentService departmentService { get; }
        IEventsService eventsService { get; }
        IExamService examService { get; }
        IExamSubmissionService examSubmissionService { get; }
        IGradeService gradService { get; }
        IHomeworkService homeworkService { get; }
        IHomeworkSubmissionService homeworkSubmissionService { get; }
        IImageService imageService { get; }
        ILessonService lessonService { get; }
        ILibraryService libraryService { get; }
        IParentService parentService { get; }
        IStudentClassService studentClassService { get; }
        IStudentService studentService { get; }
        ISubjectService subjectService { get; }
        ISubjectSpecializationService subjectSpecializationService { get; }
        ISuperAdminService superAdminService { get; }
        ITeacherService teacherService { get; }
        ITermService termService { get; }
        IUserService userService { get; }
        IVideoService videoService { get; }
        IStudentExactYearService studentExactYearService { get; }
        ISubjectTermService subjectTermService { get; }
        IConstantsService constantsService { get; }


            
    }
}
