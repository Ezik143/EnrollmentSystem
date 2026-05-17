using EnrollmentManagementSystemAPI.Models.Dto.Request;
using EnrollmentManagementSystemAPI.Models.Dto.Response;
using EnrollmentManagementSystemAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EnrollmentManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectService _subjectService;

        public SubjectController(ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubjectResponseDto>>> GetAllSubjects()
        {
            var subjects = await _subjectService.GetAllSubjectsAsync();
            return Ok(subjects);
        }

        // GET api/<SubjectController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SubjectResponseDto>> GetSubjectById(int id)
        {
            var subject = await _subjectService.GetSubjectByIdAsync(id);
            if (subject == null)
            {
                return NotFound();
            }
            return Ok(subject);
        }

        // POST api/<SubjectController>
        [HttpPost]
        public async Task<ActionResult<SubjectResponseDto>> CreateSubject([FromBody] CreateSubjectDto createSubjectDto)
        {
            try
            {
                var subjectDto = await _subjectService.CreateSubjectAsync(createSubjectDto);
                return CreatedAtAction(nameof(GetSubjectById), new { id = subjectDto.SubjectId }, subjectDto);
            }
            catch
            {
                return BadRequest();
            }
        }

        // PUT api/<SubjectController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<SubjectResponseDto>> UpdateSubject(int id, [FromBody] CreateSubjectDto updateSubjectDto)
        {
            try
            {
                var subjectDto = await _subjectService.UpdateSubjectAsync(id, updateSubjectDto);
                return Ok(subjectDto);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        // DELETE api/<SubjectController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubject(int id)
        {
            try
            {
                await _subjectService.DeleteSubjectAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
