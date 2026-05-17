using System.Linq;
using EnrollmentManagementSystemAPI.Models.Dto.Request;
using EnrollmentManagementSystemAPI.Models.Dto.Response;
using EnrollmentManagementSystemAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EnrollmentManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseSubjectController : ControllerBase
    {
        private readonly ICourseSubjectService _courseSubjectService;

        public CourseSubjectController(ICourseSubjectService courseSubjectService)
        {
            _courseSubjectService = courseSubjectService;
        }

        // GET: api/<CourseSubjectController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourseSubjectResponseDto>>> GetAllCourseSubject()
        {
            var courseSubjects = await _courseSubjectService.GetAllCourseSubjectsAsync();
            return Ok(courseSubjects);
        }

        // GET api/<CourseSubjectController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CourseSubjectResponseDto>> GetCourseSubject(int id)
        {
            var courseSubject = await _courseSubjectService.GetCourseSubjectByIdAsync(id);
            if (courseSubject == null)
            {
                return NotFound();
            }
            return Ok(courseSubject);
        }

        // POST api/<CourseSubjectController>
        [HttpPost]
        public async Task<ActionResult<CourseSubjectResponseDto>> PostCourseSubject([FromBody] CreateCourseSubjectDto createCourseSubjectDto)
        {
            try
            {
                var courseSubjectDto = await _courseSubjectService.CreateCourseSubjectAsync(createCourseSubjectDto);
                return CreatedAtAction(nameof(GetCourseSubject), new { id = courseSubjectDto.CourseSubjectId }, courseSubjectDto);
            }
            catch
            {
                return BadRequest();
            }
        }

        // PUT api/<CourseSubjectController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<CourseSubjectResponseDto>> UpdateCourseSubject(int id, [FromBody] CreateCourseSubjectDto updateCourseSubjectDto)
        {
            try
            {
                var courseSubjectDto = await _courseSubjectService.UpdateCourseSubjectAsync(id, updateCourseSubjectDto);
                return Ok(courseSubjectDto);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        // DELETE api/<CourseSubjectController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourseSubject(int id)
        {
            try
            {
                await _courseSubjectService.DeleteCourseSubjectAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
