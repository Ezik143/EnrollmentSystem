using EnrollmentManagementSystemAPI.Models.Dto.Request;
using EnrollmentManagementSystemAPI.Models.Dto.Response;
using EnrollmentManagementSystemAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EnrollmentManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorController : ControllerBase
    {
        private readonly IInstructorService _instructorService;

        public InstructorController(IInstructorService instructorService)
        {
            _instructorService = instructorService;
        }

        // GET: api/<InstructorController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InstructorResponseDto>>> GetAllInstructor()
        {
            var instructors = await _instructorService.GetAllInstructorsAsync();
            return Ok(instructors);
        }

        // GET api/<InstructorController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InstructorResponseDto>> GetInstructorById(int id)
        {
            var instructor = await _instructorService.GetInstructorByIdAsync(id);
            if (instructor == null)
            {
                return NotFound();
            }
            return Ok(instructor);
        }

        // POST api/<InstructorController>
        [HttpPost]
        public async Task<ActionResult<InstructorResponseDto>> CreateInstructor([FromBody] CreateInstructorDto createInstructorDto)
        {
            try
            {
                var instructorDto = await _instructorService.CreateInstructorAsync(createInstructorDto);
                return CreatedAtAction(nameof(GetInstructorById), new { id = instructorDto.InstructorId }, instructorDto);
            }
            catch
            {
                return BadRequest();
            }
        }

        // PUT api/<InstructorController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<InstructorResponseDto>> UpdateInstructor(int id, [FromBody] CreateInstructorDto updateInstructorDto)
        {
            try
            {
                var instructorDto = await _instructorService.UpdateInstructorAsync(id, updateInstructorDto);
                return Ok(instructorDto);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        // DELETE api/<InstructorController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInstructor(int id)
        {
            try
            {
                await _instructorService.DeleteInstructorAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
