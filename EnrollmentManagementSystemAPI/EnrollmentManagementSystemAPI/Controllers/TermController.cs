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
    public class TermController : ControllerBase
    {
        private readonly ITermService _termService;
        private readonly IMapper _mapper;
        public TermController(ITermService termService, IMapper mapper)
        {
            _termService = termService;
            _mapper = mapper;
        }
        // GET: api/<TermController>
        [HttpGet]
        public async Task<IActionResult> GetAllTerm()
        {
            var term = await _termService.GetAllAsync();
            var termDtos = _mapper.Map<List<TermResponseDto>>(term);
            return Ok(termDtos);
        }

        // GET api/<TermController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSubjectById(int id)
        {
            var term = await _termService.GetByIdAsync(id);
            if (term == null)
            {
                return NotFound();
            }

            var termDto = _mapper.Map<TermResponseDto>(term);
            return Ok(termDto);
        }

        // POST api/<TermController>
        [HttpPost]
        public async Task<IActionResult> CreateTerm(CreateTermDto createTermDto)
        {
            if (createTermDto == null)
            {
                return BadRequest();
            }

            var term = _mapper.Map<Term>(createTermDto);
            await _termService.AddAsync(term);
            var termDto = _mapper.Map<TermResponseDto>(term);
            return CreatedAtAction(nameof(GetSubjectById), new { id = termDto.TermId }, termDto);
        }

        // PUT api/<TermController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTerm(int id, CreateTermDto createTermDto)
        {
            var term = await _termService.GetByIdAsync(id);
            if (term == null)
            {
                return NotFound();
            }
            _mapper.Map(createTermDto, term);
            await _termService.UpdateAsync(term);
            var termDto = _mapper.Map<TermResponseDto>(term);
            return Ok(termDto);
        }

        // DELETE api/<TermController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTerm(int id)
        {
            var term = await _termService.GetByIdAsync(id);
            if (term == null)
            {
                return NotFound();
            }
            await _termService.DeleteAsync(id);
            return NoContent();
        }
    }
}
