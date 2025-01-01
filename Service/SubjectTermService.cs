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
    public class SubjectTermService : ISubjectTermService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        private readonly ILoggerManager _logger;

        public SubjectTermService(IRepositoryManager repository, IMapper mapper, ILoggerManager logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IEnumerable<SubjectTermDto>> GetAllSubjectTermsAsync()
        {
            var subjectTerms = await _repository.SubjectTerm.GetAllSubjectTermsAsync(trackChanges: false);
            return _mapper.Map<IEnumerable<SubjectTermDto>>(subjectTerms);
        }

        public async Task<SubjectTermDto?> GetSubjectTermByIdAsync(int subjectTermId)
        {
            var subjectTerm = await _repository.SubjectTerm.GetSubjectTermByIdAsync(subjectTermId, trackChanges: false);
            if (subjectTerm == null)
            {
                _logger.LogError($"SubjectTerm with id: {subjectTermId} not found.");
                return null;
            }

            return _mapper.Map<SubjectTermDto>(subjectTerm);
        }

        public async Task<IEnumerable<SubjectTermDto>> GetSubjectTermsByYearAndTermAsync(int termId, int yearId)
        {
            var subjectTerms = await _repository.SubjectTerm.GetSubjectTermsByYearAndTermAsync(termId, yearId, trackChanges: false);
            return _mapper.Map<IEnumerable<SubjectTermDto>>(subjectTerms);
        }

        public async Task<SubjectTermDto> CreateSubjectTermAsync(SubjectTermForCreationDto subjectTermDto)
        {
            var subjectTerm = _mapper.Map<SubjectTerm>(subjectTermDto);
            _repository.SubjectTerm.CreateSubjectTerm(subjectTerm);
            _repository.Save();
            return _mapper.Map<SubjectTermDto>(subjectTerm);
        }

        public async Task UpdateSubjectTermAsync(int subjectTermId, SubjectTermForUpdateDto subjectTermDto)
        {
            var subjectTerm = await _repository.SubjectTerm.GetSubjectTermByIdAsync(subjectTermId, trackChanges: true);
            if (subjectTerm == null)
            {
                _logger.LogError($"SubjectTerm with id: {subjectTermId} not found.");
                throw new KeyNotFoundException();
            }

            _mapper.Map(subjectTermDto, subjectTerm);
            _repository.Save();
        }

        public async Task DeleteSubjectTermAsync(int subjectTermId)
        {
            var subjectTerm = await _repository.SubjectTerm.GetSubjectTermByIdAsync(subjectTermId, trackChanges: false);
            if (subjectTerm == null)
            {
                _logger.LogError($"SubjectTerm with id: {subjectTermId} not found.");
                throw new KeyNotFoundException();
            }

            _repository.SubjectTerm.DeleteSubjectTerm(subjectTerm);
            _repository.Save();
        }


    }
}
