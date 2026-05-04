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
    public class SubjectController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public SubjectController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetAllSubjects()
        {
            var subjects = _context.Subjects.ToList();
            var subjectDtos = _mapper.Map<List<SubjectResponseDto>>(subjects);
            return Ok(subjectDtos);
        }

        // GET api/<SubjectController>/5
        [HttpGet("{id}")]
        public IActionResult GetSubjectById(int id)
        {
            var subject = _context.Subjects.Find(id);
            if (subject == null)
            {
                return NotFound();
            }
            var subjectDto = _mapper.Map<SubjectResponseDto>(subject);
            return Ok(subjectDto);
        }

        // POST api/<SubjectController>
        [HttpPost]
        public IActionResult CreateSubject([FromBody] CreateSubjectDto createSubjectDto)
        {
            if (createSubjectDto == null)
            {
                return BadRequest();
            }
            
            var subject = _mapper.Map<Subject>(createSubjectDto);
            _context.Subjects.Add(subject);
            _context.SaveChanges();
            var subjectDto = _mapper.Map<SubjectResponseDto>(subject);
            return CreatedAtAction(nameof(GetSubjectById), new { id = subject.SubjectId }, subjectDto);
        }

        // PUT api/<SubjectController>/5
        [HttpPut("{id}")]
        public IActionResult UpdateSubject(int id, [FromBody] CreateCourseDto createCourseDto)
        {
            var subject = _context.Subjects.Find(id);
            if(subject == null)
            {
                return BadRequest();
            }
            _mapper.Map(createCourseDto, subject);
            _context.SaveChanges();
            var subjectDto = _mapper.Map<CreateCourseDto>(createCourseDto);
            return Ok(subjectDto);
        }

        // DELETE api/<SubjectController>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteSubject(int id)
        {
            var subject = _context.Subjects.Find(id);
            if(subject == null)
            {
                return NotFound();
            }
            _context.Subjects.Remove(subject);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
