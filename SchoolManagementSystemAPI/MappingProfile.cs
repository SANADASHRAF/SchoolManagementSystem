using AutoMapper;
using Entities.Models;
using Shared.Dtos;


namespace SchoolManagementSystemAPI
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<UserForRegistrationDto, ApplicationUser>();
            CreateMap<ApplicationUser, ApplicationUserDto>()
               .ForMember(dest => dest.CityName, opt => opt.MapFrom(src => src.City.CityName))
               .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.ApplicationUserImage.Image.ImageUrl));

            // subject 
            CreateMap<Subject, SubjectDto>().ReverseMap();
            CreateMap<SubjectForCreationDto, Subject>();
            CreateMap<SubjectForUpdateDto, Subject>();
            
        }

    }
}
