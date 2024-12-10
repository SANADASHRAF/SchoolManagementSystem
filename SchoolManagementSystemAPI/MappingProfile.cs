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
        
        }

    }
}
