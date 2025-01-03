using Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IClassScheduleService
    {
        Task<ClassScheduleDto> GetByIdAsync(int ScheduleID);
        Task<ClassScheduleDto> AddScheduleAsync(ClassScheduleForCreationDto scheduleDto);
        Task<ClassScheduleDto> UpdateScheduleAsync(int id, ClassScheduleForUpdateDto scheduleDto);
        Task DeleteScheduleAsync(int id);
        Task<IEnumerable<ClassScheduleDto>> GetWeeklySchedulesAsync(int termId, int academicYearId);
        Task<IEnumerable<ClassScheduleDto>> GetTeacherSchedulesAsync(int teacherId, int termId, int academicYearId);
        Task<IEnumerable<ClassScheduleDto>> GetClassSchedulesAsync(int classroomId, int termId, int academicYearId);
    }
}
