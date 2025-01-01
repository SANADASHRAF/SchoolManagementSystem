using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystemAPI.Presentation.Controllers
{
    [Route("SchoolManagement/EventController/[action]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IServiceManager _service;
        private readonly ILoggerManager _logger;

        public EventController(IServiceManager service, ILoggerManager logger)
        {
            _service = service;
            _logger = logger;
        }


        [HttpGet (Name = "GetAllEvents")]
        public async Task<IActionResult> GetAllEvents()
        {
            try
            {
                var events = await _service.eventsService.GetAllEventsAsync(false);
                return Ok(events);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(GetAllEvents)} action {ex}");
                return StatusCode(500, $"Internal server error-{ex.Message}");
            }
        }


        [HttpGet (Name = "GetEventById")]
        public async Task<IActionResult> GetEventById(long eventId, bool trackChanges)
        {
            try
            {
                var eventEntity = await _service.eventsService.GetEventByIdAsync(eventId, trackChanges);
                return Ok(eventEntity);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(GetEventById)} action {ex}");
                return StatusCode(500, $"Internal server error-{ex.Message}");
            }
        }

       
        [HttpPost(Name = "CreateEvent")]
        public async Task<IActionResult> CreateEvent([FromBody] EventForCreationDto eventForCreationDto, [FromForm] IFormFileCollection images, [FromForm] IFormFileCollection videos)
        {
            if (eventForCreationDto == null)
            {
                _logger.LogError("EventForCreationDto object sent from client is null.");
                return BadRequest("EventForCreationDto object is null.");
            }

            if (images == null || !images.Any())
            {
                _logger.LogError("No images were provided for the event.");
                return BadRequest("At least one image is required for the event.");
            }

            if (videos == null || !videos.Any())
            {
                _logger.LogError("No videos were provided for the event.");
                return BadRequest("At least one video is required for the event.");
            }

            try
            {
                var createdEvent = await _service.eventsService.CreateEventAsync(eventForCreationDto, images, videos);

                return CreatedAtRoute("GetEventById", new { id = createdEvent.EventID }, createdEvent);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateEvent action: {ex.Message}");
                return StatusCode(500, "Internal server error.");
            }
        }


        [HttpDelete(Name = "DeleteEvent")]
        public async Task<IActionResult> DeleteEvent(long eventId)
        {
            try
            {
                await _service.eventsService.DeleteEventAsync(eventId);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(DeleteEvent)} action {ex}");
                return StatusCode(500, $"Internal server error-{ex.Message}");
            }
        }

    }
}
