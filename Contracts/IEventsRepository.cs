using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IEventsRepository
    {
        Task<IEnumerable<Events>> GetAllEventsAsync(bool trackChanges);
        Task<Events> GetEventByIdAsync(long eventId, bool trackChanges);
        void CreateEvent(Events eventEntity);
        
    }
}
