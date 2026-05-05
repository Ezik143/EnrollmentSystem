using AutoMapper;
using EnrollmentManagementSystemAPI.Models.Dto.Request;
using EnrollmentManagementSystemAPI.Models.Dto.Response;
using EnrollmentManagementSystemAPI.Models.Entities;
using EnrollmentManagementSystemAPI.Services.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EnrollmentManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly ICourseService _courseService;
        private readonly IValidator<CourseResponseDto> _courseResponseDtoValidator;
        private readonly IValidator<CreateCourseDto> _createCourseDtoValidator;

        public CourseController(IValidator<CourseResponseDto> courseRespondDto, IValidator<CreateCourseDto> createCourseDtoValidator, ICourseService courseService, IMapper mapper)
        {
            _courseService = courseService;
            _mapper = mapper;
            _courseResponseDtoValidator = courseRespondDto;
            _createCourseDtoValidator = createCourseDtoValidator;
        }

        // GET: api/<CourseController>
        [HttpGet]
        public async Task<IActionResult> GetAllCourse()
        {
            var courses = await _courseService.GetAllAsync();
            var courseDtos = _mapper.Map<List<CourseResponseDto>>(courses);
            return Ok(courseDtos);
        }

        // GET api/<CourseController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCourse(int id)
        {
            var course = await _courseService.GetByIdAsync(id);
            if (course == null)
            {
                return NotFound();
            }
            var courseDto = _mapper.Map<CourseResponseDto>(course);
            return Ok(courseDto);
        }

        // POST api/<CourseController>
        [HttpPost]
        public async Task<IActionResult> CreateCourse([FromBody] CreateCourseDto createCourse)
        {
            var result = await _createCourseDtoValidator.ValidateAsync(createCourse);
            
            if (!result.IsValid)
            {
                return BadRequest(new ValidationProblemDetails(result.ToDictionary()));
            }

            var course = _mapper.Map<Course>(createCourse);
            await _courseService.AddAsync(course);

            var courseDto = _mapper.Map<CourseResponseDto>(course);
            return CreatedAtAction(nameof(GetCourse), new { id = course.CourseId }, courseDto);
        }

        // PUT api/<CourseController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCourse(int id, [FromBody] CreateCourseDto updateCourse)
        {
            var result = await _createCourseDtoValidator.ValidateAsync(updateCourse);
            if (!result.IsValid)
            {
                return BadRequest(new ValidationProblemDetails(result.ToDictionary()));
            }

            var course = await _courseService.GetByIdAsync(id);
            if (course == null)
            {
                return NotFound();
            }

            _mapper.Map(updateCourse, course);

            await _courseService.UpdateAsync(course);
            var courseDto = _mapper.Map<CourseResponseDto>(course);
            return Ok(courseDto);
        }

        // DELETE api/<CourseController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {

            var course = await _courseService.GetByIdAsync(id);
            if (course == null)
            {
                return NotFound();
            }

            await _courseService.DeleteAsync(id);
            return NoContent();
        }
    }
}
