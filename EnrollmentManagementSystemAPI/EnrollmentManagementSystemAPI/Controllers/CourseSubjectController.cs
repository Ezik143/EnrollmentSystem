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
    public class CourseSubjectController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public CourseSubjectController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/<CourseSubjectController>
        [HttpGet]
        public IActionResult GetallCourseSubject()
        {
            var courseSubjects = _context.CourseSubjects.ToList();
            var courseSubjectDtos = _mapper.Map<List<CourseSubjectResponseDto>>(courseSubjects);
            return Ok(courseSubjectDtos);
        }

        // GET api/<CourseSubjectController>/5
        [HttpGet("{id}")]
        public IActionResult GetCourseSubject(int id)
        {
            var courseSubject = _context.CourseSubjects.Find(id);
            if (courseSubject == null)
            {
                return NotFound();
            }
            var courseSubjectDto = _mapper.Map<CourseSubjectResponseDto>(courseSubject);
            return Ok(courseSubjectDto);
        }

        // POST api/<CourseSubjectController>
        [HttpPost]
        public IActionResult PostCourseSubject(CreateCourseSubjectDto courseSubjectDto) 
        {
            if (courseSubjectDto == null)
            {
                return BadRequest();
            }
            var courseSubject = _mapper.Map<CourseSubject>(courseSubjectDto);
            _context.CourseSubjects.Add(courseSubject);
            _context.SaveChanges();
            var createdCourseSubjectDto = _mapper.Map<CreateCourseSubjectDto>(courseSubject);
            return CreatedAtAction(nameof(GetCourseSubject), new { id = courseSubject.CourseSubjectId }, createdCourseSubjectDto);
        }

        // PUT api/<CourseSubjectController>/5
        [HttpPut("{id}")]
        public IActionResult UpdateCourseSubject(int id, [FromBody] CreateCourseSubjectDto updateCourseSubject)
        {
            if (updateCourseSubject == null)
            {
                return BadRequest();
            }

            var courseSubject = _context.CourseSubjects.Find(id);
            if (courseSubject == null)
            {
                return NotFound();
            }

            _mapper.Map(updateCourseSubject, courseSubject);
            _context.SaveChanges();

            var courseSubjectDto = _mapper.Map<CreateCourseSubjectDto>(courseSubject);
            return CreatedAtAction(nameof(GetCourseSubject), new { id = courseSubject.CourseSubjectId }, courseSubjectDto);
        }

        // DELETE api/<CourseSubjectController>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteCourseSubject(int id)
        {
            var courseSubject = _context.CourseSubjects.Find(id);
            if (courseSubject == null)
            {
                return NotFound();
            }

            _context.CourseSubjects.Remove(courseSubject);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
