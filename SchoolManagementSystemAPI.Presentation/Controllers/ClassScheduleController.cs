using Contracts;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystemAPI.Presentation.Controllers
{
    [Route("SchoolManagement/ClassScheduleController/[action]")]
    [ApiController]
    public class ClassScheduleController : ControllerBase
    {
        private readonly IServiceManager _service;
        private readonly ILoggerManager _logger;
        public ClassScheduleController(IServiceManager service, ILoggerManager logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet(Name = "GetScheduleById")]
        public async Task<IActionResult> GetScheduleById(int id)
        {
            try
            {
                var schedule = await _service.classScheduleService.GetByIdAsync(id);
                return Ok(schedule);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error in getting schedule: {ex.Message}");
            }
        }

        [HttpGet(Name = "GetWeeklySchedules")]
        public async Task<IActionResult> GetWeeklySchedules([FromQuery] int termId, [FromQuery] int academicYearId)
        {
            try
            {
                var schedules = await _service.classScheduleService.GetWeeklySchedulesAsync(termId, academicYearId);
                return Ok(schedules);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error in getting weekly schedules: {ex.Message}");
            }
        }

        [HttpGet(Name = "GetTeacherSchedules")]
        public async Task<IActionResult> GetTeacherSchedules(int teacherId, [FromQuery] int termId, [FromQuery] int academicYearId)
        {
            try
            {
                var schedules = await _service.classScheduleService.GetTeacherSchedulesAsync(teacherId, termId, academicYearId);
                return Ok(schedules);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error in getting teacher schedules: {ex.Message}");
            }
        }

        [HttpGet(Name = "GetClassSchedules")]
        public async Task<IActionResult> GetClassSchedules(int classroomId, [FromQuery] int termId, [FromQuery] int academicYearId)
        {
            try
            {
                var schedules = await _service.classScheduleService.GetClassSchedulesAsync(classroomId, termId, academicYearId);
                return Ok(schedules);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error in getting class schedules: {ex.Message}");
            }
        }

        [HttpPost(Name = "ClassScheduleForCreationDto")]
        public async Task<IActionResult> CreateSchedule([FromBody] ClassScheduleForCreationDto scheduleDto)
        {
            try
            {
                var result = await _service.classScheduleService.AddScheduleAsync(scheduleDto);
                return CreatedAtAction(nameof(GetScheduleById), new { id = result.ScheduleID }, result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error in creating schedule: {ex.Message}");
            }
        }

        [HttpPut(Name = "UpdateSchedule")]
        public async Task<IActionResult> UpdateSchedule(int id, [FromBody] ClassScheduleForUpdateDto scheduleDto)
        {
            try
            {
                var updatedSchedule = await _service.classScheduleService.UpdateScheduleAsync(id, scheduleDto);
                return Ok(updatedSchedule);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error in updating schedule: {ex.Message}");
            }
        }

        [HttpDelete(Name = "DeleteSchedule")]
        public async Task<IActionResult> DeleteSchedule(int id)
        {
            try
            {
                await _service.classScheduleService.DeleteScheduleAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest($"Error in deleting schedule: {ex.Message}");
            }
        }

    }
}
