using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IClassScheduleRepository
    {
        Task<ClassSchedule> GetByIdAsync(int id);
        Task<IEnumerable<ClassSchedule>> GetByTermAndYearAsync(int termId, int academicYearId);
        Task<IEnumerable<ClassSchedule>> GetByTeacherAndTermAsync(int teacherId, int termId, int academicYearId);
        Task<IEnumerable<ClassSchedule>> GetByClassroomAndTermAsync(int classroomId, int termId, int academicYearId);
        Task CreateClassScheduleAsync(ClassSchedule classSchedule);
        Task UpdateClassScheduleAsync(ClassSchedule classSchedule);
        Task DeleteClassScheduleAsync(ClassSchedule classSchedule);
    }
}
