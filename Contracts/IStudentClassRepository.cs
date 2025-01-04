using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IStudentClassRepository
    {
        void AddStudentToClassAsync(StudentClass studentClass);
        Task<IEnumerable<StudentClass>> GetStudentsByClassroomAsync(int classroomId);
        void RemoveStudentFromClassAsync(int studentClassId);
    }
}
