using AutoMapper;
using Contracts;
using Entities.Models;
using Service.Contracts;
using Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ClassScheduleService : IClassScheduleService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public ClassScheduleService(IRepositoryManager repository, ILoggerManager logger,IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<ClassScheduleDto> AddScheduleAsync(ClassScheduleForCreationDto scheduleDto)
        {
            var schedule = _mapper.Map<ClassSchedule>(scheduleDto);
           await _repository.ClassSchedule.CreateClassScheduleAsync(schedule);
            return _mapper.Map<ClassScheduleDto>(schedule);
        }

        public async Task<ClassScheduleDto> UpdateScheduleAsync(int id, ClassScheduleForUpdateDto scheduleDto)
        {
            var schedule = await _repository.ClassSchedule.GetByIdAsync(id);
            if (schedule == null) throw new Exception("Schedule not found.");
            _mapper.Map(scheduleDto, schedule);
            await _repository.ClassSchedule.UpdateClassScheduleAsync(schedule);
            _repository.Save();
            return _mapper.Map<ClassScheduleDto>(schedule);
        }

        public async Task DeleteScheduleAsync(int id)
        {
            var schedule = await _repository.ClassSchedule.GetByIdAsync(id);
            if (schedule == null) throw new Exception("Schedule not found.");
            await _repository.ClassSchedule.DeleteClassScheduleAsync(schedule);
            _repository.Save();
        }

        public async Task<IEnumerable<ClassScheduleDto>> GetWeeklySchedulesAsync(int termId, int academicYearId)
        {
            var schedules = await _repository.ClassSchedule.GetByTermAndYearAsync(termId, academicYearId);
            return _mapper.Map<IEnumerable<ClassScheduleDto>>(schedules);
        }

        public async Task<IEnumerable<ClassScheduleDto>> GetTeacherSchedulesAsync(int teacherId, int termId, int academicYearId)
        {
            var schedules = await _repository.ClassSchedule.GetByTeacherAndTermAsync(teacherId, termId, academicYearId);
            return _mapper.Map<IEnumerable<ClassScheduleDto>>(schedules);
        }

        public async Task<IEnumerable<ClassScheduleDto>> GetClassSchedulesAsync(int classroomId, int termId, int academicYearId)
        {
            var schedules = await _repository.ClassSchedule.GetByClassroomAndTermAsync(classroomId, termId, academicYearId);
            return _mapper.Map<IEnumerable<ClassScheduleDto>>(schedules);
        }

        public async Task<ClassScheduleDto> GetByIdAsync(int ScheduleID)
        {
            var schedules = await _repository.ClassSchedule.GetByIdAsync(ScheduleID);
            return _mapper.Map<ClassScheduleDto>(schedules);
        }
    }
}