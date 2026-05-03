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
    public class EnrollmentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly AutoMapper.IMapper _mapper;
        public EnrollmentController(ApplicationDbContext context, IMapper mapper) 
        {
            _context = context;
            _mapper  = mapper;
        }

        // GET: api/<EnrollmentController>
        [HttpGet]
        public IActionResult GetAllEnrollment() 
        {
            var enrollments = _context.Enrollments.ToList();
            var enrollmentDtos = _mapper.Map<List<EnrollmentResponseDto>>(enrollments);
            return Ok(enrollmentDtos);
        }

        // GET api/<EnrollmentController>/5
        [HttpGet("{id}")]
        public IActionResult GetEnrollment(int id) 
        {
            var enrollment = _context.Enrollments.Find(id);
            if(enrollment == null)
            {
                return NotFound();
            }
            var enrollmentDto = _mapper.Map<EnrollmentResponseDto>(enrollment);
            return Ok(enrollmentDto);
        }

        // POST api/<EnrollmentController>
        [HttpPost]
        public IActionResult CreateEnrollment([FromBody] CreateEnrollmentDto createEnrollmentDto)
        {
            if (createEnrollmentDto == null)
            {
                return BadRequest();
            }
            
            var enrollment = _mapper.Map<Enrollment>(createEnrollmentDto);
            _context.Enrollments.Add(enrollment);
            _context.SaveChanges();
            var enrollmentResponseDto = _mapper.Map<EnrollmentResponseDto>(enrollment);
            return CreatedAtAction(nameof(GetEnrollment), new { id = enrollment.EnrollmentId }, enrollmentResponseDto);
        }

        // PUT api/<EnrollmentController>/5
        [HttpPut("{id}")]
        public IActionResult EditEnrollment(int id, [FromBody] CreateEnrollmentDto updateEnrollmentDto)
        {
            if(updateEnrollmentDto == null)
            {
                return BadRequest();
            }
            var enrollment = _context.Enrollments.Find(id);
            if(enrollment == null)
            {
                return NotFound();
            }

            _mapper.Map(updateEnrollmentDto, enrollment);
            _context.SaveChanges();

            var enrollmentDto = _mapper.Map<EnrollmentResponseDto>(enrollment);
            return Ok(enrollmentDto);
        }

        // DELETE api/<EnrollmentController>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteEnrollment(int id)
        {
            var enrollment = _context.Enrollments.Find(id);
            if (enrollment == null)
            {
                return NotFound();
            }
            var enrollmentDto = _mapper.Map<EnrollmentResponseDto>(enrollment);
            _context.Remove(enrollment);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
