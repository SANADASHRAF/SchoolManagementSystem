using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Repository
{
    public class SubjectRepository : RepositoryBase<Subject>, ISubjectRepository
    {
        public SubjectRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<Subject>> GetAllSubjectsAsync(bool trackChanges) =>
            await FindAll(trackChanges).ToListAsync();

        public async Task<Subject?> GetSubjectByIdAsync(int subjectId, bool trackChanges) =>
            await FindByCondition(s => s.SubjectID == subjectId, trackChanges).FirstOrDefaultAsync();

        public void CreateSubject(Subject subject) => Create(subject);

        public void UpdateSubject(Subject subject) => Update(subject);

        public void DeleteSubject(Subject subject) => Delete(subject);

        public async Task<IEnumerable<Subject>> GetSubjectsByTermAndYearAsync(int termId, int yearId, bool trackChanges)
        {
            var subjectTerms = await RepositoryContext.subjectTerm
                .Include(st => st.Subject)
                .Where(st => st.TermID == termId && st.AcademicYearID == yearId)
                .ToListAsync();

            return subjectTerms.Select(st => st.Subject).ToList();
        }
    }
}
