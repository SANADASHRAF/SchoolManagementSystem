using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Entities.Models;
using Contracts;
namespace Repository
{
   public class AcademicYearRepository : RepositoryBase<AcademicYear>, IAcademicYearRepository
    {
        public AcademicYearRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
        {
        }
    }
}
