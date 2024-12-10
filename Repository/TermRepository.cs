using Contracts;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Repository
{
    public class TermRepository : RepositoryBase<Term>, ITermRepository
    {
        public TermRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
        {
        }
    }
}
