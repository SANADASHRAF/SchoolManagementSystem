using Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
    [Route("SchoolManagement/SubjectsController/[action]")]
    [ApiController]
    public class SubjectsController : ControllerBase
    {
        private readonly IServiceManager _service;
        private readonly ILoggerManager _logger;

        public SubjectsController(IServiceManager service, ILoggerManager logger )
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet(Name = "GetAllSubjects")]
        public async Task<IActionResult> GetAllSubjects()
        {
            try
            {
                var subjects = await _service.subjectService.GetAllSubjectsAsync();
                return Ok(subjects);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(GetAllSubjects)} service method {ex.Message}");
                return StatusCode(500, $"Internal server error, {ex.Message}");
            }
        }


        [HttpGet(Name = "GetSubjectById")]
        public async Task<IActionResult> GetSubjectById(int subjectId)
        {
            try
            {
                var subject = await _service.subjectService.GetSubjectByIdAsync(subjectId);
                if (subject == null)
                    return NotFound();
                return Ok(subject);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(GetSubjectById)} service method {ex.Message}");
                return StatusCode(500, $"Internal server error , {ex.Message}");
            }
        }


        [HttpGet(Name = "GetSubjectsByTermAndYear")]
        public async Task<IActionResult> GetSubjectsByTermAndYear(int termId, int yearId)
        {
            try
            {
                var subjects = await _service.subjectService.GetSubjectsByTermAndYearAsync(termId, yearId);
                return Ok(subjects);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(GetSubjectsByTermAndYear)} service method {ex.Message}");
                return StatusCode(500, $"Internal server error, {ex.Message}");
            }
        }
       
        
        [HttpPost(Name = "CreateSubject")]
        public async Task<IActionResult> CreateSubject([FromBody] SubjectForCreationDto subject)
        {
            try
            {
                if (subject == null)
                {
                    _logger.LogError("Subject object sent from client is null.");
                    return BadRequest("Subject object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid subject object sent from client.");
                    return BadRequest("Invalid model object");
                }

                return Ok("Subject Created Successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(CreateSubject)} service method {ex.Message}");
                return StatusCode(500, $"Internal server error, {ex.Message}");
            }
        }
      
        
        [HttpPut(Name = "UpdateSubject")]
        public async Task<IActionResult> UpdateSubject(int subjectId, [FromBody] SubjectForUpdateDto subject)
        {
            try
            {
                if (subject == null)
                {
                    _logger.LogError("Subject object sent from client is null.");
                    return BadRequest("Subject object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid subject object sent from client.");
                    return BadRequest("Invalid model object");
                }
                await _service.subjectService.UpdateSubjectAsync(subjectId, subject);
                return Ok("Subject Updated Successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(UpdateSubject)} service method {ex.Message}");
                return StatusCode(500, $"Internal server error, {ex.Message}");
            }
        }
       
        
        [HttpDelete(Name = "DeleteSubject")]
        public async Task<IActionResult> DeleteSubject(int subjectId)
        {
            try
            {
                await _service.subjectService.DeleteSubjectAsync(subjectId);
                return Ok("Subject Deleted Successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(DeleteSubject)} service method {ex.Message}");
                return StatusCode(500, $"Internal server error,  {ex.Message}");
            }
        }


    }
}
