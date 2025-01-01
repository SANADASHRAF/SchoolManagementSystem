using AutoMapper;
using Entities.Models;
using Shared.Dtos;


namespace SchoolManagementSystemAPI
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            //sourse >> destination
            CreateMap<UserForRegistrationDto, ApplicationUser>();

            CreateMap<ApplicationUser, ApplicationUserDto>()
               .ForMember(dest => dest.CityName, opt => opt.MapFrom(src => src.City.CityName))
               .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.ApplicationUserImage.Image.ImageUrl));

            // subject 
            CreateMap<Subject, SubjectDto>().ReverseMap();
            CreateMap<SubjectForCreationDto, Subject>();
            CreateMap<SubjectForUpdateDto, Subject>();

            //SubjectTerm
            CreateMap<SubjectTerm, SubjectTermDto>().ReverseMap();
            CreateMap<SubjectTermForCreationDto, SubjectTerm>();
            CreateMap<SubjectTermForUpdateDto, SubjectTerm>();

            // Constants
            CreateMap<AcademicYear, AcademicYearDto>();
            CreateMap<City, CityDto>();
            CreateMap<Classperiod, ClassPeriodDto>();
            CreateMap<Day, DayDto>();
            CreateMap<Term, TermDto>();
            CreateMap<Classroom, ClassroomDTO>();


            //events
            CreateMap<Events, EventDto>()
            .ForMember(dest => dest.Images, opt => opt.MapFrom(src => src.EventsImages.Select(ei => ei.Image.ImageUrl)))
            .ForMember(dest => dest.Videos, opt => opt.MapFrom(src => src.Videos.Select(ev => ev.Video.VideoUrl)));

            CreateMap<EventForCreationDto, Events>();
        }

    }
}
