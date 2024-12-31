using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ISubjectRepository
    {
        Task<IEnumerable<Subject>> GetAllSubjectsAsync(bool trackChanges);
        Task<Subject?> GetSubjectByIdAsync(int subjectId, bool trackChanges);
        Task<IEnumerable<Subject>> GetSubjectsByTermAndYearAsync(int termId, int yearId, bool trackChanges);
        void CreateSubject(Subject subject);
        void UpdateSubject(Subject subject);
        void DeleteSubject(Subject subject);
    }
}
