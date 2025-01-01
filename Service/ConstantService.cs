using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Repository;
using Service.Contracts;
using Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ConstantService : IConstantService
    {

        private readonly IMapper _mapper;
        private readonly RepositoryContext _repository;

        public ConstantService(IMapper mapper, RepositoryContext repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<IEnumerable<AcademicYearDto>> GetAcademicYears()
        {
            try
            {
                var academicYears = await _repository.AcademicYears.ToListAsync();
                return _mapper.Map<IEnumerable<AcademicYearDto>>(academicYears);
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching academic years", ex);
            }
        }

        public async Task<IEnumerable<CityDto>> GetCities()
        {
            try
            {
                var cities = await _repository.Cities.ToListAsync();
                return _mapper.Map<IEnumerable<CityDto>>(cities);
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching cities", ex);
            }
        }

        public async Task<IEnumerable<ClassPeriodDto>> GetClassPeriods()
        {
            try
            {
                var classPeriods = await _repository.Classperiod.ToListAsync();
                return _mapper.Map<IEnumerable<ClassPeriodDto>>(classPeriods);
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching class periods", ex);
            }
        }

        public async Task<IEnumerable<DayDto>> GetDays()
        {
            try
            {
                var days = await _repository.day.ToListAsync();
                return _mapper.Map<IEnumerable<DayDto>>(days);
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching days", ex);
            }
        }

        public async Task<IEnumerable<TermDto>> GetTerms()
        {
            try
            {
                var terms = await _repository.Terms.ToListAsync();
                return _mapper.Map<IEnumerable<TermDto>>(terms);
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching terms", ex);
            }
        }
        public async Task<IEnumerable<ClassroomDTO>> GetClassroom()
        {
            try
            {
                var classroom = await _repository.classroom.Include(x=>x.AcademicYear).ToListAsync();
                
                return _mapper.Map<IEnumerable<ClassroomDTO>>(classroom);
               
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching classroom", ex);
            }
        }
    }
}
