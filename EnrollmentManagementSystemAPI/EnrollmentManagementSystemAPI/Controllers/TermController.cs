using EnrollmentManagementSystemAPI.Models.Dto.Request;
using EnrollmentManagementSystemAPI.Models.Dto.Response;
using EnrollmentManagementSystemAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EnrollmentManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TermController : ControllerBase
    {
        private readonly ITermService _termService;

        public TermController(ITermService termService)
        {
            _termService = termService;
        }

        // GET: api/<TermController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TermResponseDto>>> GetAllTerm()
        {
            var terms = await _termService.GetAllTermsAsync();
            return Ok(terms);
        }

        // GET api/<TermController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TermResponseDto>> GetTermById(int id)
        {
            var term = await _termService.GetTermByIdAsync(id);
            if (term == null)
            {
                return NotFound();
            }
            return Ok(term);
        }

        // POST api/<TermController>
        [HttpPost]
        public async Task<ActionResult<TermResponseDto>> CreateTerm([FromBody] CreateTermDto createTermDto)
        {
            try
            {
                var termDto = await _termService.CreateTermAsync(createTermDto);
                return CreatedAtAction(nameof(GetTermById), new { id = termDto.TermId }, termDto);
            }
            catch
            {
                return BadRequest();
            }
        }

        // PUT api/<TermController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<TermResponseDto>> UpdateTerm(int id, [FromBody] CreateTermDto updateTermDto)
        {
            try
            {
                var termDto = await _termService.UpdateTermAsync(id, updateTermDto);
                return Ok(termDto);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        // DELETE api/<TermController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTerm(int id)
        {
            try
            {
                await _termService.DeleteTermAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
