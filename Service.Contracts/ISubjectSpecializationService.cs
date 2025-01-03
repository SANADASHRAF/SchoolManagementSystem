using Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface ISubjectSpecializationService
    {

        Task<List<SubjectSpecializationDto>> GetSubjectsByTeacherAsync(int teacherId, bool trackChanges);
        Task<SubjectSpecializationDto> GetSpecializationByIdAsync(int id, bool trackChanges);
        Task<List<TeacherSubjectDto>> GetTeachersBySubjectAsync(int subjectId,bool trackChanges);
        Task<SubjectSpecializationDto> CreateSubjectSpecializationAsync(SubjectSpecializationForCreationDto specializationDto);
        Task DeleteSubjectSpecializationAsync(int specializationId);
    }
}
