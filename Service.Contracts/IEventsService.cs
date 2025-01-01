using Microsoft.AspNetCore.Http;
using Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IEventsService
    {
        Task<IEnumerable<EventDto>> GetAllEventsAsync(bool trackChanges);
        Task<EventDto> GetEventByIdAsync(long eventId, bool trackChanges);
        Task<EventDto> CreateEventAsync(EventForCreationDto eventDto, IFormFileCollection images, IFormFileCollection videos);
        Task DeleteEventAsync(long eventId);
    }
}
