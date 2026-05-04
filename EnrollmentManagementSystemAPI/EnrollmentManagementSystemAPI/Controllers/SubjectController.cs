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
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectService _subjectService;
        private readonly IMapper _mapper;

        public SubjectController(ISubjectService subjectService, IMapper mapper)
        {
            _subjectService = subjectService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllSubjects()
        {
            var subjects = await _subjectService.GetAllAsync();
            var subjectDtos = _mapper.Map<List<SubjectResponseDto>>(subjects);
            return Ok(subjectDtos);
        }

        // GET api/<SubjectController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSubjectById(int id)
        {
            var subject = await _subjectService.GetByIdAsync(id);
            if (subject == null)
            {
                return NotFound();
            }
            var subjectDto = _mapper.Map<SubjectResponseDto>(subject);
            return Ok(subjectDto);
        }

        // POST api/<SubjectController>
        [HttpPost]
        public async Task<IActionResult> CreateSubject([FromBody] CreateSubjectDto createSubjectDto)
        {
            if (createSubjectDto == null)
            {
                return BadRequest();
            }

            var subject = _mapper.Map<Subject>(createSubjectDto);
            await _subjectService.AddAsync(subject);
            var subjectDto = _mapper.Map<SubjectResponseDto>(subject);
            return CreatedAtAction(nameof(GetSubjectById), new { id = subject.SubjectId }, subjectDto);
        }

        // PUT api/<SubjectController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSubject(int id, [FromBody] CreateSubjectDto updateSubjectDto)
        {
            var subject = await _subjectService.GetByIdAsync(id);
            if (subject == null)
            {
                return NotFound();
            }

            _mapper.Map(updateSubjectDto, subject);
            await _subjectService.UpdateAsync(subject);

            var subjectDto = _mapper.Map<SubjectResponseDto>(subject);
            return Ok(subjectDto);
        }

        // DELETE api/<SubjectController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubject(int id)
        {
            var subject = await _subjectService.GetByIdAsync(id);
            if (subject == null)
            {
                return NotFound();
            }
            await _subjectService.DeleteAsync(id);
            return NoContent();
        }
    }
}
