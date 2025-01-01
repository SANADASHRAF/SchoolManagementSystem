using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ISubjectTermRepository
    {
        Task<IEnumerable<SubjectTerm>> GetAllSubjectTermsAsync(bool trackChanges);
        Task<SubjectTerm?> GetSubjectTermByIdAsync(int subjectTermId, bool trackChanges);
        Task<IEnumerable<SubjectTerm>> GetSubjectTermsByYearAndTermAsync(int termId, int yearId, bool trackChanges);
        void CreateSubjectTerm(SubjectTerm subjectTerm);
        void UpdateSubjectTerm(SubjectTerm subjectTerm);
        void DeleteSubjectTerm(SubjectTerm subjectTerm);
    }
}
