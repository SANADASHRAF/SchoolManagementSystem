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
    [Route("SchoolManagement/SubjectTermsController/[action]")]
    [ApiController] 
    public class SubjectTermsController : ControllerBase
    {
        private readonly IServiceManager _service;
        private readonly ILoggerManager _logger;

        public SubjectTermsController(IServiceManager service, ILoggerManager logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet(Name = "GetAllSubjectTerms")]
        public async Task<IActionResult> GetAllSubjectTerms()
        {
            try
            {
                var subjectTerms = await _service.subjectTermService.GetAllSubjectTermsAsync();
                return Ok(subjectTerms);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpGet("{id}", Name = "GetSubjectTermById")]
        public async Task<IActionResult> GetSubjectTermById(int id)
        {
            try
            {
                var subjectTerm = await _service.subjectTermService.GetSubjectTermByIdAsync(id);
                if (subjectTerm == null) return NotFound();

                return Ok(subjectTerm);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpGet("term/{termId}/year/{yearId}", Name = "GetSubjectTermsByYearAndTerm")]
        public async Task<IActionResult> GetSubjectTermsByYearAndTerm(int termId, int yearId)
        {
            try
            {
                var subjectTerms = await _service.subjectTermService.GetSubjectTermsByYearAndTermAsync(termId, yearId);
                return Ok(subjectTerms);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpPost(Name = "CreateSubjectTerm")]
        public async Task<IActionResult> CreateSubjectTerm([FromBody] SubjectTermForCreationDto subjectTermDto)
        {
            try
            {
                if (subjectTermDto == null) return BadRequest("SubjectTerm data is null.");

                var createdSubjectTerm = await _service.subjectTermService.CreateSubjectTermAsync(subjectTermDto);
                return CreatedAtRoute("GetSubjectTermById", new { id = createdSubjectTerm.SubjectTermID }, createdSubjectTerm);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpPut("{id}", Name = "UpdateSubjectTerm")]
        public async Task<IActionResult> UpdateSubjectTerm(int id, [FromBody] SubjectTermForUpdateDto subjectTermDto)
        {
            try
            {
                if (subjectTermDto == null) return BadRequest("SubjectTerm data is null.");

                await _service.subjectTermService.UpdateSubjectTermAsync(id, subjectTermDto);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpDelete("{id}", Name = "DeleteSubjectTerm")]
        public async Task<IActionResult> DeleteSubjectTerm(int id)
        {
            try
            {
                await _service.subjectTermService.DeleteSubjectTermAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
