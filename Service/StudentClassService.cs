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
    public class StudentClassService : IStudentClassService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public StudentClassService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper )
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }


        public async Task<IEnumerable<StudentDto>> GetStudentsByClassroomAsync(int classroomId)
        {
            try
            {
                var studentClasses = await _repository.StudentClass.GetStudentsByClassroomAsync(classroomId);
                return _mapper.Map<IEnumerable<StudentDto>>(studentClasses.Select(sc => sc.Student));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in {nameof(GetStudentsByClassroomAsync)}: {ex.Message}");
                throw;
            }
        }

        public async Task AddStudentToClassAsync(StudentClassForCreationDto studentClassDto)
        {
            try
            {
                var studentClass = _mapper.Map<StudentClass>(studentClassDto);
                _repository.StudentClass.AddStudentToClassAsync(studentClass);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in {nameof(AddStudentToClassAsync)}: {ex.Message}");
                throw;
            }
        }

        public async Task RemoveStudentFromClassAsync(int studentClassId)
        {
            try
            {
                 _repository.StudentClass.RemoveStudentFromClassAsync(studentClassId);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in {nameof(RemoveStudentFromClassAsync)}: {ex.Message}");
                throw;
            }
        }

    }
}