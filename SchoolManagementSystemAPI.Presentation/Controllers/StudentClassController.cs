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
    [Route("SchoolManagement/StudentClassController/[action]")]
    [ApiController]
    public class StudentClassController : ControllerBase
    {
        private readonly IServiceManager _service;
        private readonly ILoggerManager _logger;
        public StudentClassController(IServiceManager service, ILoggerManager logger)
        {
            _service = service;
            _logger = logger;
        }


        [HttpGet(Name = "GetStudentsByClassroom")]
        public async Task<IActionResult> GetStudentsByClassroom(int classroomId)
        {
            try
            {
                var students = await _service.studentClassService.GetStudentsByClassroomAsync(classroomId);
                return Ok(students);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost (Name = "AddStudentToClass")]
        public async Task<IActionResult> AddStudentToClass([FromBody] StudentClassForCreationDto studentClassDto)
        {
            try
            {
                await _service.studentClassService.AddStudentToClassAsync(studentClassDto);
                return Ok("Student added to class successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{studentClassId}")]
        public async Task<IActionResult> RemoveStudentFromClass(int studentClassId)
        {
            try
            {
                await _service.studentClassService.RemoveStudentFromClassAsync(studentClassId);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

    }
}
