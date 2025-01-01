using Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IConstantService
    {


        Task<IEnumerable<AcademicYearDto>> GetAcademicYears();
        Task<IEnumerable<CityDto>> GetCities();
        Task<IEnumerable<ClassPeriodDto>> GetClassPeriods();
        Task<IEnumerable<DayDto>> GetDays();
        Task<IEnumerable<TermDto>> GetTerms();
        Task<IEnumerable<ClassroomDTO>> GetClassroom();
      
    }
}
