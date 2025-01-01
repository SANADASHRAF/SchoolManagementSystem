using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystemAPI.Presentation.Controllers
{
    [Route("SchoolManagement/ConstantsContrroller/[action]")]
    [ApiController]
    public class ConstantsContrroller : ControllerBase
    {
        private readonly IServiceManager _service;
        public ConstantsContrroller(IServiceManager service)
        {
            _service = service;
        }

        [HttpGet(Name = "GetAcademicYears")]
        public async Task<IActionResult> GetAcademicYears()
        {
            try
            {
                var academicYears = await _service.constantsService
                    .GetAcademicYears();
                return Ok(academicYears);

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet(Name = "GetCities")]
        public async Task<IActionResult> GetCities()
        {
            try
            {
                var cities = await _service.constantsService.GetCities();
                return Ok(cities);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet(Name = "GetClassPeriods")]
        public async Task<IActionResult> GetClassPeriods()
        {
            try
            {
                var classPeriods = await _service.constantsService.GetClassPeriods();
                return Ok(classPeriods);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet(Name = "GetDays")]
        public async Task<IActionResult> GetDays()
        {
            try
            {
                var days = await _service.constantsService.GetDays();
                return Ok(days);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet(Name = "GetTerms")]
        public async Task<IActionResult> GetTerms()
        {
            try
            {
                var terms = await _service.constantsService.GetTerms();
                return Ok(terms);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }



    }
}
