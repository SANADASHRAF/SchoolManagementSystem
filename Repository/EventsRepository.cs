using Contracts;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class EventsRepository : RepositoryBase<Events>, IEventsRepository
    {
        public EventsRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
        {
        }
    }
}
