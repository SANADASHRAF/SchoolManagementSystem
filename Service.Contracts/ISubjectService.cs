using Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface ISubjectService
    {
        Task<IEnumerable<SubjectDto>> GetAllSubjectsAsync();
        Task<SubjectDto?> GetSubjectByIdAsync(int subjectId);
        Task<SubjectDto> CreateSubjectAsync(SubjectForCreationDto subjectDto);
        Task UpdateSubjectAsync(int subjectId, SubjectForUpdateDto subjectDto);
        Task DeleteSubjectAsync(int subjectId);
        Task<IEnumerable<SubjectDto>> GetSubjectsByTermAndYearAsync(int termId, int yearId);
    }
}
