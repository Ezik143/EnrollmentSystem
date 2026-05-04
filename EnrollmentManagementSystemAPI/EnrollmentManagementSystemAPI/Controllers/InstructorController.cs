using AutoMapper;
using EnrollmentManagementSystemAPI.Models.Dto.Request;
using EnrollmentManagementSystemAPI.Models.Dto.Response;
using EnrollmentManagementSystemAPI.Models.Entities;
using EnrollmentManagementSystemAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EnrollmentManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorController : ControllerBase
    {
        private readonly IInstructorService _instructorService;
        private readonly IMapper _mapper;
        public InstructorController(IInstructorService instructorService, IMapper mapper)
        {
            _instructorService = instructorService;
            _mapper = mapper;
        }

        // GET: api/<InstructorController>
        [HttpGet]
        public async Task<IActionResult> GetAllInstructor()
        {
            var instructors = await _instructorService.GetAllAsync();
            var instructorDtos = _mapper.Map<List<InstructorResponseDto>>(instructors);
            return Ok(instructorDtos);
        }

        // GET api/<InstructorController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetInstructorById(int id)
        {
            var instructor = await _instructorService.GetByIdAsync(id);
            if (instructor == null)
            {
                return NotFound();
            }
            var instructorDto = _mapper.Map<InstructorResponseDto>(instructor);
            return Ok(instructorDto);
        }

        // POST api/<InstructorController>
        [HttpPost]
        public async Task<IActionResult> CreateInstructor([FromBody] CreateInstructorDto createInstructorDto)
        {
            if (createInstructorDto == null)
            {
                return BadRequest();
            }

            var instructor = _mapper.Map<Instructor>(createInstructorDto);
            await _instructorService.AddAsync(instructor);
            var instructorDto = _mapper.Map<InstructorResponseDto>(instructor);
            return CreatedAtAction(nameof(GetInstructorById), new { id = instructor.InstructorId }, instructorDto);
        }

        // PUT api/<InstructorController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateInstructor(int id, [FromBody] CreateInstructorDto updateInstructorDto)
        {
            if (updateInstructorDto == null)
            {
                return BadRequest();
            }
            var instructor = await _instructorService.GetByIdAsync(id);
            if (instructor == null)
            {
                return NotFound();
            }

            _mapper.Map(updateInstructorDto, instructor);
            await _instructorService.UpdateAsync(instructor);
            var instructorDto = _mapper.Map<InstructorResponseDto>(instructor);
            return Ok(instructorDto);
        }

        // DELETE api/<InstructorController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInstructor(int id)
        {
            var instructor = await _instructorService.GetByIdAsync(id);
            if (instructor == null)
            {
                return NotFound();
            }

            await _instructorService.DeleteAsync(id);
            return NoContent();
        }
    }
}
