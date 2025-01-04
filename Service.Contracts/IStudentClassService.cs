using Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IStudentClassService
    {  
        Task<IEnumerable<StudentDto>> GetStudentsByClassroomAsync(int classroomId);
        Task AddStudentToClassAsync(StudentClassForCreationDto studentClassDto);
        Task RemoveStudentFromClassAsync(int studentClassId);
    }
}
