using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Repository
{
    public class ImageRepository : RepositoryBase<Entities.Models.Image>, IImageRepository
    {
        public ImageRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
        {
        }
    }
}
