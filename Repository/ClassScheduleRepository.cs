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
    public class ClassScheduleRepository : RepositoryBase<ClassSchedule>, IClassScheduleRepository
    {
        public ClassScheduleRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
        {
        }

        public async Task<ClassSchedule> GetByIdAsync(int id)
        {
            return await FindByCondition(c => c.ScheduleID.Equals(id), false)
                    .FirstOrDefaultAsync();
        }
        public async Task<IEnumerable<ClassSchedule>> GetByClassroomAndTermAsync(int classroomId, int termId, int academicYearId)
        {
            return await FindByCondition(c => c.ClassroomID.Equals(classroomId) 
                         && c.TermID.Equals(termId) 
                         && c.AcademicYearID.Equals(academicYearId), false)
                         .ToListAsync();
        }
        public async Task<IEnumerable<ClassSchedule>> GetByTeacherAndTermAsync(int teacherId, int termId, int academicYearId)
        {
            return await FindByCondition(c => c.TeacherID.Equals(teacherId) 
                         && c.TermID.Equals(termId) 
                         && c.AcademicYearID.Equals(academicYearId), false)
                        .ToListAsync();
        }

        public async Task<IEnumerable<ClassSchedule>> GetByTermAndYearAsync(int termId, int academicYearId)
        {
            return await FindByCondition(c => c.TermID.Equals(termId) 
                         && c.AcademicYearID.Equals(academicYearId), false)
                        .ToListAsync();
        }

        public async Task CreateClassScheduleAsync(ClassSchedule classSchedule)=> Create(classSchedule);

        public async Task DeleteClassScheduleAsync(ClassSchedule classSchedule) => Delete(classSchedule);

        public async Task UpdateClassScheduleAsync(ClassSchedule classSchedule) => Update(classSchedule);

    }
}
