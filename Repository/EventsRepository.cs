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
    public class EventsRepository : RepositoryBase<Events>, IEventsRepository
    {
        public EventsRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<Events>> GetAllEventsAsync(bool trackChanges) =>
        await FindAll(trackChanges)
            .Include(e => e.EventsImages)
            .ThenInclude(ei => ei.Image)
            .Include(e => e.Videos)
            .ThenInclude(ev => ev.Video)
            .Where(e => e.Isdeleted == false)
            .ToListAsync();

        public async Task<Events> GetEventByIdAsync(long eventId, bool trackChanges) =>
            await FindByCondition(e => e.EventID == eventId, trackChanges)
                .Include(e => e.EventsImages)
                .ThenInclude(ei => ei.Image)
                .Include(e => e.Videos)
                .ThenInclude(ev => ev.Video)
              .Where(e => e.Isdeleted == false)
                .FirstOrDefaultAsync();

        public void CreateEvent(Events eventEntity) => Create(eventEntity);

    }
}
