using AutoMapper;
using EnrollmentManagementSystemAPI.data;
using EnrollmentManagementSystemAPI.Models.Dto.Request;
using EnrollmentManagementSystemAPI.Models.Dto.Response;
using EnrollmentManagementSystemAPI.Models.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EnrollmentManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public InstructorController(ApplicationDbContext context, IMapper mapper) 
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/<InstructorController>
        [HttpGet]
        public IActionResult GetAllInstructor()
        {
            var instructors = _context.Instructors.ToList();
            var instructorDtos = _mapper.Map<List<InstructorResponseDto>>(instructors);
            return Ok(instructorDtos);
        }

        // GET api/<InstructorController>/5
        [HttpGet("{id}")]
        public IActionResult GetInstructorById(int id)
        {
            var instructor = _context.Instructors.Find(id);
            if (instructor == null)
            {
                return NotFound();
            }
            var instructorDto = _mapper.Map<InstructorResponseDto>(instructor);
            return Ok(instructorDto);
        }

        // POST api/<InstructorController>
        [HttpPost]
        public IActionResult CreateInstructor([FromBody] CreateInstructorDto createInstructorDto)
        {
            if (createInstructorDto == null)
            {
                return BadRequest();
            }
            
            var instructor = _mapper.Map<Instructor>(createInstructorDto);
            _context.Add(instructor);
            _context.SaveChanges();
            var instructorDto = _mapper.Map<InstructorResponseDto>(instructor);
            return CreatedAtAction(nameof(GetInstructorById), new { id = instructor.InstructorId }, instructorDto);
        }

        // PUT api/<InstructorController>/5
        [HttpPut("{id}")]
        public IActionResult UpdateInstructor(int id, [FromBody] CreateInstructorDto updateInstructorDto)
        {
            if(updateInstructorDto == null)
            {
                return BadRequest();
            }
            var instructor = _context.Instructors.Find(id);
            if (instructor == null)
            {
                return NotFound();
            }

           var updatedInstructor = _mapper.Map(updateInstructorDto, instructor);
            _context.Update(updatedInstructor);
            _context.SaveChanges();
            var instructorDto = _mapper.Map<InstructorResponseDto>(updatedInstructor);
            return Ok(instructorDto);
        }

        // DELETE api/<InstructorController>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteInstructor(int id)
        {
            var instructor = _context.Instructors.Find(id);
            if (instructor == null)
            {
                return NotFound();
            }

            _context.Instructors.Remove(instructor);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
