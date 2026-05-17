using EnrollmentManagementSystemAPI.Models.Dto.Request;
using EnrollmentManagementSystemAPI.Models.Dto.Response;
using EnrollmentManagementSystemAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EnrollmentManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SectionController : ControllerBase
    {
        private readonly ISectionService _sectionService;

        public SectionController(ISectionService sectionService)
        {
            _sectionService = sectionService;
        }

        // GET: api/<SectionController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SectionResponseDto>>> GetAllSection()
        {
            var sections = await _sectionService.GetAllSectionsAsync();
            return Ok(sections);
        }

        // GET api/<SectionController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SectionResponseDto>> GetSectionById(int id)
        {
            var section = await _sectionService.GetSectionByIdAsync(id);
            if (section == null)
            {
                return NotFound();
            }
            return Ok(section);
        }

        // POST api/<SectionController>
        [HttpPost]
        public async Task<ActionResult<SectionResponseDto>> CreateSection([FromBody] CreateSectionDto createSectionDto)
        {
            try
            {
                var sectionDto = await _sectionService.CreateSectionAsync(createSectionDto);
                return CreatedAtAction(nameof(GetSectionById), new { id = sectionDto.SectionId }, sectionDto);
            }
            catch
            {
                return BadRequest();
            }
        }

        // PUT api/<SectionController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<SectionResponseDto>> UpdateSection(int id, [FromBody] CreateSectionDto updateSectionDto)
        {
            try
            {
                var sectionDto = await _sectionService.UpdateSectionAsync(id, updateSectionDto);
                return Ok(sectionDto);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        // DELETE api/<SectionController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSection(int id)
        {
            try
            {
                await _sectionService.DeleteSectionAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
