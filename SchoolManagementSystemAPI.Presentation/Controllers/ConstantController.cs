using Contracts;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystemAPI.Presentation.Controllers
{
    [Route("SchoolManagement/ConstantController/[action]")]
    [ApiController]
    public class ConstantController : ControllerBase
    {
        private readonly IServiceManager _service;
        private readonly ILoggerManager _logger;
        public ConstantController(IServiceManager service, ILoggerManager logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet(Name = "GetAcademicYears")]
        public async Task<IActionResult> GetAcademicYears()
        {
            try
            {
                var academicYears = await _service.constantService.GetAcademicYears();
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
                var cities = await _service.constantService.GetCities();
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
                var classPeriods = await _service.constantService.GetClassPeriods();
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
                var days = await _service.constantService.GetDays();
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
                var terms = await _service.constantService.GetTerms();
                return Ok(terms);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet(Name = "GetClassroom")]
        public async Task<IActionResult> GetClassroom()
        {
            try
            {
                var classroom = await _service.constantService.GetClassroom();
                return Ok(classroom);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        



    }
}
