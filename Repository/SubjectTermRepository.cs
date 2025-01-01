using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class SubjectTermRepository : RepositoryBase<SubjectTerm>, ISubjectTermRepository
    {
        public SubjectTermRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<SubjectTerm>> GetAllSubjectTermsAsync(bool trackChanges) =>
            await FindAll(trackChanges).ToListAsync();

        public async Task<SubjectTerm?> GetSubjectTermByIdAsync(int subjectTermId, bool trackChanges) =>
            await FindByCondition(st => st.SubjectTermID == subjectTermId, trackChanges).FirstOrDefaultAsync();

        public async Task<IEnumerable<SubjectTerm>> GetSubjectTermsByYearAndTermAsync(int termId, int yearId, bool trackChanges) =>
            await FindByCondition(st => st.TermID == termId && st.AcademicYearID == yearId, trackChanges).ToListAsync();

        public void CreateSubjectTerm(SubjectTerm subjectTerm) => Create(subjectTerm);

        public void UpdateSubjectTerm(SubjectTerm subjectTerm) => Update(subjectTerm);

        public void DeleteSubjectTerm(SubjectTerm subjectTerm) => Delete(subjectTerm);
    }
}
