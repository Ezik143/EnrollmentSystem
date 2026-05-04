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
    public class StudentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public StudentController(ApplicationDbContext context, IMapper mapper) 
        {
            _context = context;
            _mapper = mapper;
        }
        // GET: api/<StudentController>
        [HttpGet]
        public IActionResult GetAllStudent()
        {
            var student = _context.Students.ToList();
            var studentDtos = _mapper.Map<List<StudentResponseDto>>(student);
            return Ok(studentDtos);
        }

        // GET api/<StudentController>/5
        [HttpGet("{id}")]
        public IActionResult GetStudentById(int id)
        {
            var student = _context.Students.Find(id);
            if (student == null)
            {
                return NotFound();
            }
            var studentDto = _mapper.Map<StudentResponseDto>(student);
            return Ok(studentDto);
        }

        // POST api/<StudentController>
        [HttpPost]
        public IActionResult CreateStudent([FromBody] CreateStudentDto createStudentDto)
        {
            if (createStudentDto == null)
            {
                return BadRequest();
            }
            
            var student = _mapper.Map<Student>(createStudentDto);
            _context.Students.Add(student);
            _context.SaveChanges();
            
            var studentResponseDto = _mapper.Map<StudentResponseDto>(student);
            return CreatedAtAction(nameof(GetStudentById), new { id = student.StudentId }, studentResponseDto);

        }

        // PUT api/<StudentController>/5
        [HttpPut("{id}")]
        public IActionResult UpdateStudent(int id, [FromBody] CreateStudentDto updateStudentDto)
        {
            var student = _context.Students.Find(id);
            if(student == null)
            {
                return NotFound();
            }
            
            _mapper.Map(updateStudentDto, student);
            _context.SaveChanges();
            
            var studentDto = _mapper.Map<StudentResponseDto>(student);
            return Ok(studentDto);
        }

        // DELETE api/<StudentController>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            var student = _context.Students.Find(id);
            if (student == null)
            {
                return NotFound();
            }
            _context.Students.Remove(student);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
