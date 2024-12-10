﻿using Contracts;
using Entities.Models;
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
    }
}
