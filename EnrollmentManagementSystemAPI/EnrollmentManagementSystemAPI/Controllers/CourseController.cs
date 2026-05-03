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
    public class CourseController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        private readonly IMapper _mapper;

        public CourseController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/<CourseController>
        [HttpGet]
        public IActionResult GetAllCourse()
        {
            var courses = _context.Courses.ToList();
            var courseDtos = _mapper.Map<List<CourseSubjectResponseDto>>(courses);
            return Ok(courseDtos);
        }

        // GET api/<CourseController>/5
        [HttpGet("{id}")]
        public IActionResult GetCourse(int id)
        {
            var course = _context.Courses.Find(id);
            if (course == null)
            {
                return NotFound();
            }
            var courseDto = _mapper.Map<CourseSubjectResponseDto>(course);
            return Ok(courseDto);
        }

        // POST api/<CourseController>
        [HttpPost]
        public IActionResult CreateCourse([FromBody] CreateCourseDto createCourse)
        {
            if (createCourse == null)
            {
                return BadRequest();
            }
            
            var course = _mapper.Map<Course>(createCourse);
            _context.Courses.Add(course);
            _context.SaveChanges();

            var courseDto = _mapper.Map<CreateCourseDto>(course);
            return CreatedAtAction(nameof(GetCourse), new { id = course.CourseId }, courseDto);
        }

        // PUT api/<CourseController>/5
        [HttpPut("{id}")]
        public IActionResult UpdateCourse(int id, [FromBody] CreateCourseDto updateCourse)
        {
            if(updateCourse == null)
            {   
                return BadRequest();
            }

            var course = _context.Courses.Find(id);
            if(course == null)
            {
                return NotFound();
            }

            _mapper.Map(updateCourse, course);

            _context.SaveChanges();
            var courseDto = _mapper.Map<CreateCourseDto>(course);
            return Ok(courseDto);
        }

        // DELETE api/<CourseController>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteCourse(int id)
        {

            var course = _context.Courses.Find(id);
            if (course == null)
            {
                return NotFound();
            }

            _context.Courses.Remove(course);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
