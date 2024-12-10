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
    public class TeacherRepository : RepositoryBase<Teacher>, ITeacherRepository
    {
        public TeacherRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
        {
        }
    }
}
