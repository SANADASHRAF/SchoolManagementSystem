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


            //book
            CreateMap<Book, BookDto>();
            CreateMap<BookForCreationDto, Book>();

            // SubjectSpecialization 
            CreateMap<SubjectSpecialization, SubjectSpecializationDto>()
                .ForMember(dest => dest.SubjectName, opt => opt.MapFrom(src => src.Subject.SubjectName))
                .ForMember(dest => dest.TeacherName, opt => opt.MapFrom(src => src.Teacher.User.Name));

            CreateMap<SubjectSpecializationForCreationDto, SubjectSpecialization>();

            // TeacherSubjectDto Mapping
            CreateMap<Teacher, TeacherSubjectDto>()
                .ForMember(dest => dest.TeacherName, opt => opt.MapFrom(src => src.User.Name))
                .ForMember(dest => dest.Subjects, opt => opt.MapFrom(src => src.subjectSpecializations.Select(ss => ss.Subject.SubjectName)));


            // ClassSchedule
            CreateMap<ClassScheduleForCreationDto, ClassSchedule>();
            CreateMap<ClassScheduleForUpdateDto, ClassSchedule>();
            CreateMap<ClassSchedule, ClassScheduleDto>()
                .ForMember(dest => dest.ClassroomName, opt => opt.MapFrom(src => src.Classroom.ClassroomName))
                .ForMember(dest => dest.SubjectName, opt => opt.MapFrom(src => src.Subject.SubjectName))
                .ForMember(dest => dest.TeacherName, opt => opt.MapFrom(src => src.Teacher.UserID)); 
        }

    }
}
