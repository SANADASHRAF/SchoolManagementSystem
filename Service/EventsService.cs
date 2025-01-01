using AutoMapper;
using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using OpenQA.Selenium;
using Service.Contracts;
using Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class EventsService : IEventsService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        private readonly ILoggerManager _logger;

        public EventsService(IRepositoryManager repository, IMapper mapper, ILoggerManager logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IEnumerable<EventDto>> GetAllEventsAsync(bool trackChanges)
        {
            var events = await _repository.Events.GetAllEventsAsync(trackChanges);
            return _mapper.Map<IEnumerable<EventDto>>(events);
        }

        public async Task<EventDto> GetEventByIdAsync(long eventId, bool trackChanges)
        {
            var eventEntity = await _repository.Events.GetEventByIdAsync(eventId, trackChanges);
            if (eventEntity == null)
                throw new NotFoundException($"Event with id {eventId} not found");

            return _mapper.Map<EventDto>(eventEntity);
        }

        public async Task<EventDto> CreateEventAsync(EventForCreationDto eventDto, IFormFileCollection images, IFormFileCollection videos)
        {
            if (eventDto == null)
                throw new ArgumentNullException(nameof(eventDto));

          
            var eventEntity = _mapper.Map<Events>(eventDto);

     
            foreach (var image in images)
            {
                var imageFileName = $"{Guid.NewGuid()}{Path.GetExtension(image.FileName)}";
                var uploadResult = await _repository.Image.UploadImageToServer(image, imageFileName);
                if (!string.IsNullOrEmpty(uploadResult))
                    throw new Exception(uploadResult);

          
                var imageEntity = new Image
                {
                    ImageUrl = imageFileName,
                    imagename = Path.GetFileNameWithoutExtension(imageFileName)
                };

                var eventImage = new EventsImage
                {
                    Image = imageEntity
                };

                eventEntity.EventsImages.Add(eventImage);
            }

            foreach (var video in videos)
            {
                var videoFileName = $"{Guid.NewGuid()}{Path.GetExtension(video.FileName)}";
                var uploadResult = await _repository.Video.UploadVideoToServer(video, videoFileName);
                if (!string.IsNullOrEmpty(uploadResult))
                    throw new Exception(uploadResult);

        
                var videoEntity = new Video
                {
                    VideoUrl = videoFileName,
                    VideoName = Path.GetFileNameWithoutExtension(videoFileName)
                };

                var eventVideo = new EventVideo
                {
                    Video = videoEntity
                };

                eventEntity.Videos.Add(eventVideo);
            }

           
            _repository.Events.CreateEvent(eventEntity);
            _repository.Save();

          
            var createdEventDto = _mapper.Map<EventDto>(eventEntity);
            return createdEventDto;
        }


        public async Task DeleteEventAsync(long eventId)
        {
            var eventEntity = await _repository.Events.GetEventByIdAsync(eventId, trackChanges: false);
            if (eventEntity == null)
                throw new NotFoundException($"Event with id {eventId} not found");
            eventEntity.Isdeleted = true;
             _repository.Save();
        }

    }
}