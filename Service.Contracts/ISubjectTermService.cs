using Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface ISubjectTermService
    {
        Task<IEnumerable<SubjectTermDto>> GetAllSubjectTermsAsync();
        Task<SubjectTermDto?> GetSubjectTermByIdAsync(int subjectTermId);
        Task<IEnumerable<SubjectTermDto>> GetSubjectTermsByYearAndTermAsync(int termId, int yearId);
        Task<SubjectTermDto> CreateSubjectTermAsync(SubjectTermForCreationDto subjectTermDto);
        Task UpdateSubjectTermAsync(int subjectTermId, SubjectTermForUpdateDto subjectTermDto);
        Task DeleteSubjectTermAsync(int subjectTermId);
    }
}
