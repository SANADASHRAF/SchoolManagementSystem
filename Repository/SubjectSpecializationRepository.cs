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
    public class SubjectSpecializationRepository : RepositoryBase<SubjectSpecialization>, ISubjectSpecializationRepository
    {
        public SubjectSpecializationRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
        {
        }

        public async Task<SubjectSpecialization> GetByIdAsync(int id, bool trackChanges)
        {
            return await FindByCondition(s => s.SpecializationID == id, trackChanges).FirstOrDefaultAsync();
        }
        public async Task<List<SubjectSpecialization>> GetSpecializationsByTeacherAsync(int teacherId, bool trackChanges)
        {
            return await FindByCondition(s => s.TeacherID == teacherId, trackChanges)
                .Include(s => s.Subject)
                .ToListAsync();
        }

        public async Task<List<SubjectSpecialization>> GetTeachersBySubjectAsync(int subjectId, bool trackChanges)
        {
            return await FindByCondition(s => s.SubjectID == subjectId ,trackChanges)
                .Include(s => s.Teacher.User)
                .Include(s => s.Subject)
                .ToListAsync();
        }

        public void CreateSpecialization(SubjectSpecialization specialization)=>Create(specialization);
        
        public void DeleteSpecialization(SubjectSpecialization specialization)=> Delete(specialization);
       
    }
}
