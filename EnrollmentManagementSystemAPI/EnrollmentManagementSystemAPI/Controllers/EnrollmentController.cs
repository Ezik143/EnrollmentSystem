using EnrollmentManagementSystemAPI.Models.Dto.Request;
using EnrollmentManagementSystemAPI.Models.Dto.Response;
using EnrollmentManagementSystemAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EnrollmentManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentController : ControllerBase
    {
        private readonly IEnrollmentService _enrollmentService;

        public EnrollmentController(IEnrollmentService enrollmentService)
        {
            _enrollmentService = enrollmentService;
        }

        // GET: api/<EnrollmentController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EnrollmentResponseDto>>> GetAllEnrollment()
        {
            var enrollments = await _enrollmentService.GetAllEnrollmentsAsync();
            return Ok(enrollments);
        }

        // GET api/<EnrollmentController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EnrollmentResponseDto>> GetEnrollment(int id)
        {
            var enrollment = await _enrollmentService.GetEnrollmentByIdAsync(id);
            if (enrollment == null)
            {
                return NotFound();
            }
            return Ok(enrollment);
        }

        // POST api/<EnrollmentController>
        [HttpPost]
        public async Task<ActionResult<EnrollmentResponseDto>> CreateEnrollment([FromBody] CreateEnrollmentDto createEnrollmentDto)
        {
            try
            {
                var enrollmentDto = await _enrollmentService.CreateEnrollmentAsync(createEnrollmentDto);
                return CreatedAtAction(nameof(GetEnrollment), new { id = enrollmentDto.EnrollmentId }, enrollmentDto);
            }
            catch
            {
                return BadRequest();
            }
        }

        // PUT api/<EnrollmentController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<EnrollmentResponseDto>> EditEnrollment(int id, [FromBody] CreateEnrollmentDto updateEnrollmentDto)
        {
            try
            {
                var enrollmentDto = await _enrollmentService.UpdateEnrollmentAsync(id, updateEnrollmentDto);
                return Ok(enrollmentDto);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        // DELETE api/<EnrollmentController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEnrollment(int id)
        {
            try
            {
                await _enrollmentService.DeleteEnrollmentAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
