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
    public class EnrollmentController : ControllerBase
    {
        private readonly IEnrollmentService _enrollmentService;
        private readonly AutoMapper.IMapper _mapper;
        public EnrollmentController(IEnrollmentService enrollmentService, IMapper mapper)
        {
            _enrollmentService = enrollmentService;
            _mapper = mapper;
        }

        // GET: api/<EnrollmentController>
        [HttpGet]
        public async Task<IActionResult> GetAllEnrollment()
        {
            var enrollments = await _enrollmentService.GetAllAsync();
            var enrollmentDtos = _mapper.Map<List<EnrollmentResponseDto>>(enrollments);
            return Ok(enrollmentDtos);
        }

        // GET api/<EnrollmentController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEnrollment(int id)
        {
            var enrollment = await _enrollmentService.GetByIdAsync(id);
            if (enrollment == null)
            {
                return NotFound();
            }
            var enrollmentDto = _mapper.Map<EnrollmentResponseDto>(enrollment);
            return Ok(enrollmentDto);
        }

        // POST api/<EnrollmentController>
        [HttpPost]
        public async Task<IActionResult> CreateEnrollment(CreateEnrollmentDto createEnrollmentDto)
        {
            if (createEnrollmentDto == null)
            {
                return BadRequest();
            }

            var enrollment = _mapper.Map<Enrollment>(createEnrollmentDto);
            await _enrollmentService.AddAsync(enrollment);
            var enrollmentResponseDto = _mapper.Map<EnrollmentResponseDto>(enrollment);
            return CreatedAtAction(nameof(GetEnrollment), new { id = enrollment.EnrollmentId }, enrollmentResponseDto);
        }

        // PUT api/<EnrollmentController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> EditEnrollment(int id, CreateEnrollmentDto updateEnrollmentDto)
        {
            if (updateEnrollmentDto == null)
            {
                return BadRequest();
            }
            var enrollment = await _enrollmentService.GetByIdAsync(id);
            if (enrollment == null)
            {
                return NotFound();
            }

            _mapper.Map(updateEnrollmentDto, enrollment);
            await _enrollmentService.UpdateAsync(enrollment);

            var enrollmentDto = _mapper.Map<EnrollmentResponseDto>(enrollment);
            return Ok(enrollmentDto);
        }

        // DELETE api/<EnrollmentController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEnrollment(int id)
        {
            var enrollment = await _enrollmentService.GetByIdAsync(id);
            if (enrollment == null)
            {
                return NotFound();
            }
            await _enrollmentService.DeleteAsync(id);
            return NoContent();
        }
    }
}
