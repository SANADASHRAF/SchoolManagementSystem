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
    public class StudentClassRepository : RepositoryBase<StudentClass>, IStudentClassRepository
    {
        public StudentClassRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<StudentClass>> GetStudentsByClassroomAsync(int classroomId)
        {
            return await FindByCondition(sc => sc.ClassroomID == classroomId, false)
                        .Include(sc => sc.Student)
                        .ThenInclude(s => s.User)
                        .ToListAsync();
        }

        public void AddStudentToClassAsync(StudentClass studentClass) => Create(studentClass);

        public void RemoveStudentFromClassAsync(int studentClassId)
        {
            var studentClass = FindByCondition(sc => sc.StudentClassID == studentClassId, false).FirstOrDefault();
            if (studentClass != null)
                Delete(studentClass);
        }

    }
}
