using Entities.Models;
using Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IConstantsService
    {
         Task<IEnumerable<DayDto>> GetDays();
         Task<IEnumerable<CityDto>> GetCities();
         Task<IEnumerable<TermDto>> GetTerms();
         Task<IEnumerable<ClassPeriodDto>> GetClassPeriods();
         Task<IEnumerable<AcademicYearDto>> GetAcademicYears();


    }
}
