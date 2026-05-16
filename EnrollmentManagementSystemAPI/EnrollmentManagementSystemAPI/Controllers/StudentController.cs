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
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;
        public StudentController(IStudentService studentService, IMapper mapper)
        {
            _studentService = studentService;
            _mapper = mapper;
        }
        // GET: api/<StudentController>
        [HttpGet]
        public async Task<IActionResult> GetAllStudent()
        {
            var student = await _studentService.GetAllAsync();
            var studentDtos = _mapper.Map<List<StudentResponseDto>>(student);
            return Ok(studentDtos);
        }

        // GET api/<StudentController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentById(int id)
        {
            var student = await _studentService.GetByIdAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            var studentDto = _mapper.Map<StudentResponseDto>(student);
            return Ok(studentDto);
        }

        // POST api/<StudentController>
        [HttpPost]
        public async Task<IActionResult> CreateStudent(CreateStudentDto createStudentDto)
        {
            if (createStudentDto == null)
            {
                return BadRequest();
            }

            var student = _mapper.Map<Student>(createStudentDto);
            await _studentService.AddAsync(student);

            var studentResponseDto = _mapper.Map<StudentResponseDto>(student);
            return CreatedAtAction(nameof(GetStudentById), new { id = student.StudentId }, studentResponseDto);

        }

        // PUT api/<StudentController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(int id, CreateStudentDto updateStudentDto)
        {
            var student = await _studentService.GetByIdAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            _mapper.Map(updateStudentDto, student);
            await _studentService.UpdateAsync(student);

            var studentDto = _mapper.Map<StudentResponseDto>(student);
            return Ok(studentDto);
        }

        // DELETE api/<StudentController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var student = await _studentService.GetByIdAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            await _studentService.DeleteAsync(id);
            return NoContent();
        }
    }
}
