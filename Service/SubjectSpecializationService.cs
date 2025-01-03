using AutoMapper;
using Contracts;
using Entities.Models;
using OpenQA.Selenium;
using Service.Contracts;
using Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class SubjectSpecializationService : ISubjectSpecializationService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public SubjectSpecializationService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

       
        public async Task<List<SubjectSpecializationDto>> GetSubjectsByTeacherAsync(int teacherId, bool trackChanges)
        {
            var specializations = await _repository.SubjectSpecialization
                .GetSpecializationsByTeacherAsync(teacherId, trackChanges);

            return _mapper.Map<List<SubjectSpecializationDto>>(specializations);
        }

        public async Task<List<TeacherSubjectDto>> GetTeachersBySubjectAsync(int subjectId, bool trackChanges)
        {
            var teachers = await _repository.SubjectSpecialization
                .GetTeachersBySubjectAsync(subjectId, trackChanges);

            return _mapper.Map<List<TeacherSubjectDto>>(teachers);
        }

        public async Task<SubjectSpecializationDto> GetSpecializationByIdAsync(int id, bool trackChanges)
        {
            try
            {
                var specialization = await _repository.SubjectSpecialization.GetByIdAsync(id, trackChanges);

                if (specialization == null)
                {
                    throw new Exception($"Specialization with ID {id} not found.");
                }
                var specializationDto = _mapper.Map<SubjectSpecializationDto>(specialization);

                return specializationDto;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in {nameof(GetSpecializationByIdAsync)}: {ex.Message}");
                throw;
            }
        }

        public async Task<SubjectSpecializationDto> CreateSubjectSpecializationAsync(SubjectSpecializationForCreationDto specializationDto)
        {
            var specializationEntity = _mapper.Map<SubjectSpecialization>(specializationDto);
            _repository.SubjectSpecialization.CreateSpecialization(specializationEntity);
            _repository.Save();

            return _mapper.Map<SubjectSpecializationDto>(specializationEntity);
        }

        public async Task DeleteSubjectSpecializationAsync(int specializationId)
        {
            var specialization = await _repository.SubjectSpecialization
                .GetByIdAsync(specializationId, trackChanges: false);

            if (specialization == null)
                throw new NotFoundException($"Specialization with ID {specializationId} not found.");

            _repository.SubjectSpecialization.DeleteSpecialization(specialization);
            _repository.Save();
        }

    }
}
