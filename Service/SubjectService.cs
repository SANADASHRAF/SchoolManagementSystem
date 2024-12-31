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
    public class SubjectService : ISubjectService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        private readonly ILoggerManager _logger;

        public SubjectService(IRepositoryManager repository, IMapper mapper, ILoggerManager logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IEnumerable<SubjectDto>> GetAllSubjectsAsync()
        {
            var subjects = await _repository.Subject.GetAllSubjectsAsync(trackChanges: false);
            return _mapper.Map<IEnumerable<SubjectDto>>(subjects);
        }

        public async Task<SubjectDto?> GetSubjectByIdAsync(int subjectId)
        {
            var subject = await _repository.Subject.GetSubjectByIdAsync(subjectId, trackChanges: false);
            if (subject == null)
            {
                _logger.LogError($"Subject with id: {subjectId} not found.");
                return null;
            }

            return _mapper.Map<SubjectDto>(subject);
        }
        public async Task<IEnumerable<SubjectDto>> GetSubjectsByTermAndYearAsync(int termId, int yearId)
        {
            var subjects = await _repository.Subject.GetSubjectsByTermAndYearAsync(termId, yearId, trackChanges: false);
            return _mapper.Map<IEnumerable<SubjectDto>>(subjects);
        }

        public async Task<SubjectDto> CreateSubjectAsync(SubjectForCreationDto subjectDto)
        {
            var subject = _mapper.Map<Subject>(subjectDto);
            _repository.Subject.CreateSubject(subject);
            _repository.Save();
            return _mapper.Map<SubjectDto>(subject);
        }

        public async Task UpdateSubjectAsync(int subjectId, SubjectForUpdateDto subjectDto)
        {
            var subject = await _repository.Subject.GetSubjectByIdAsync(subjectId, trackChanges: true);
            if (subject == null)
            {
                _logger.LogError($"Subject with id: {subjectId} not found.");
                throw new KeyNotFoundException();
            }

            _mapper.Map(subjectDto, subject);
             _repository.Save();
        }

        public async Task DeleteSubjectAsync(int subjectId)
        {
            var subject = await _repository.Subject.GetSubjectByIdAsync(subjectId, trackChanges: false);
            if (subject == null)
            {
                _logger.LogError($"Subject with id: {subjectId} not found.");
                throw new KeyNotFoundException();
            }

            _repository.Subject.DeleteSubject(subject);
            _repository.Save();
        }

    }
}
