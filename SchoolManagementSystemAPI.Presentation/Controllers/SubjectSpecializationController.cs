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
    [Route("SchoolManagement/SubjectSpecializationController/[action]")]
    [ApiController]
    public class SubjectSpecializationController : ControllerBase
    {
        private readonly IServiceManager _service;
        private readonly ILoggerManager _logger;

        public SubjectSpecializationController(IServiceManager service, ILoggerManager logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet(Name = "GetSpecializationById")]
        public async Task<IActionResult> GetSpecializationById(int id)
        {
            try
            {
                var specialization = await _service.subjectSpecializationService.GetSpecializationByIdAsync(id, trackChanges: false);

                if (specialization == null)
                    return NotFound($"Specialization with ID {id} not found.");

                return Ok(specialization);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in {nameof(GetSpecializationById)}: {ex.Message}");
                return StatusCode(500, $"Internal server error.-{ex.Message}");
            }
        }


        [HttpGet(Name = "GetSubjectsByTeacher")]
        public async Task<IActionResult> GetSubjectsByTeacher(int teacherId)
        {
            try
            {
                var subjects = await _service.subjectSpecializationService.GetSubjectsByTeacherAsync(teacherId, trackChanges: false);

                if (subjects == null || !subjects.Any())
                    return NotFound($"No subjects found for teacher ID {teacherId}.");

                return Ok(subjects);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in {nameof(GetSubjectsByTeacher)}: {ex.Message}");
                return StatusCode(500, $"Internal server error.-{ex.Message}");
            }
        }


        [HttpGet(Name = "GetTeachersBySubject")]
        public async Task<IActionResult> GetTeachersBySubject(int subjectId)
        {
            try
            {
                var teachers = await _service.subjectSpecializationService.GetTeachersBySubjectAsync(subjectId, trackChanges: false);

                if (teachers == null || !teachers.Any())
                    return NotFound($"No teachers found for subject ID {subjectId}.");

                return Ok(teachers);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in {nameof(GetTeachersBySubject)}: {ex.Message}");
                return StatusCode(500, $"Internal server error.-{ex.Message}");
            }
        }


        [HttpPost(Name = "CreateSpecialization")]
        public async Task<IActionResult> CreateSpecialization([FromBody] SubjectSpecializationForCreationDto specializationDto)
        {
            try
            {
                if (specializationDto == null)
                    return BadRequest("Specialization data is null.");

                var createdSpecialization = await _service.subjectSpecializationService.CreateSubjectSpecializationAsync(specializationDto);

                return CreatedAtRoute("GetSpecializationById", new { id = createdSpecialization.SpecializationID }, createdSpecialization);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in {nameof(CreateSpecialization)}: {ex.Message}");
                return StatusCode(500, $"Internal server error.-{ex.Message}");
            }
        }


        [HttpDelete(Name = "DeleteSpecialization")]
        public async Task<IActionResult> DeleteSpecialization(int id)
        {
            try
            {
                await _service.subjectSpecializationService.DeleteSubjectSpecializationAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in {nameof(DeleteSpecialization)}: {ex.Message}");
                return StatusCode(500, $"Internal server error.-{ex.Message}");
            }
        }

    }
}
