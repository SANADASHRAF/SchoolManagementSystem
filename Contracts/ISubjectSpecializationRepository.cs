using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ISubjectSpecializationRepository
    {
        Task<SubjectSpecialization> GetByIdAsync(int id, bool trackChanges);
        Task<List<SubjectSpecialization>> GetSpecializationsByTeacherAsync(int teacherId, bool trackChanges);
        Task<List<SubjectSpecialization>> GetTeachersBySubjectAsync(int subjectId, bool trackChanges);
        void CreateSpecialization(SubjectSpecialization specialization);
        void DeleteSpecialization(SubjectSpecialization specialization);

    }
}
