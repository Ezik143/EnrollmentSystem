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
    public class CourseSubjectController : ControllerBase
    {
        private readonly ICourseSubjectService _courseSubjectService;
        private readonly IMapper _mapper;
        public CourseSubjectController(ICourseSubjectService courseSubjectService, IMapper mapper)
        {
            _courseSubjectService = courseSubjectService;
            _mapper = mapper;
        }

        // GET: api/<CourseSubjectController>
        [HttpGet]
        public async Task<IActionResult> GetallCourseSubject()
        {
            var courseSubjects = await _courseSubjectService.GetAllAsync();
            var courseSubjectDtos = _mapper.Map<List<CourseSubjectResponseDto>>(courseSubjects);
            return Ok(courseSubjectDtos);
        }

        // GET api/<CourseSubjectController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCourseSubject(int id)
        {
            var courseSubject = await _courseSubjectService.GetByIdAsync(id);
            if (courseSubject == null)
            {
                return NotFound();
            }
            var courseSubjectDto = _mapper.Map<CourseSubjectResponseDto>(courseSubject);
            return Ok(courseSubjectDto);
        }

        // POST api/<CourseSubjectController>
        [HttpPost]
        public async Task<IActionResult> PostCourseSubject(CreateCourseSubjectDto courseSubjectDto)
        {
            if (courseSubjectDto == null)
            {
                return BadRequest();
            }
            var courseSubject = _mapper.Map<CourseSubject>(courseSubjectDto);
            await _courseSubjectService.AddAsync(courseSubject);
            var createdCourseSubjectDto = _mapper.Map<CreateCourseSubjectDto>(courseSubject);
            return CreatedAtAction(nameof(GetCourseSubject), new { id = courseSubject.CourseSubjectId }, createdCourseSubjectDto);
        }

        // PUT api/<CourseSubjectController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCourseSubject(int id, [FromBody] CreateCourseSubjectDto updateCourseSubject)
        {
            if (updateCourseSubject == null)
            {
                return BadRequest();
            }

            var courseSubject = await _courseSubjectService.GetByIdAsync(id);
            if (courseSubject == null)
            {
                return NotFound();
            }

            _mapper.Map(updateCourseSubject, courseSubject);
            await _courseSubjectService.UpdateAsync(courseSubject);

            var courseSubjectDto = _mapper.Map<CreateCourseSubjectDto>(courseSubject);
            return CreatedAtAction(nameof(GetCourseSubject), new { id = courseSubject.CourseSubjectId }, courseSubjectDto);
        }

        // DELETE api/<CourseSubjectController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourseSubject(int id)
        {
            var courseSubject = await _courseSubjectService.GetByIdAsync(id);
            if (courseSubject == null)
            {
                return NotFound();
            }

            await _courseSubjectService.DeleteAsync(id);
            return NoContent();
        }
    }
}
