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
    public class SectionController : ControllerBase
    {
        private readonly ISectionService _sectionService;
        private readonly IMapper _mapper;

        public SectionController(ISectionService sectionService, IMapper mapper)
        {
            _sectionService = sectionService;
            _mapper = mapper;
        }
        // GET: api/<SectionController>
        [HttpGet]
        public async Task<IActionResult> GetSectionById()
        {
            var sections = await _sectionService.GetAllAsync();
            var sectionDtos = _mapper.Map<List<SectionResponseDto>>(sections);
            return Ok(sectionDtos);
        }

        // GET api/<SectionController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSectionById(int id)
        {
            var section = await _sectionService.GetByIdAsync(id);
            if (section == null)
            {
                return NotFound();
            }

            var sectionDto = _mapper.Map<SectionResponseDto>(section);
            return Ok(sectionDto);
        }

        // POST api/<SectionController>
        [HttpPost]
        public async Task<IActionResult> CreateSection(CreateSectionDto createSectionRequest)
        {
            if (createSectionRequest == null)
            {
                return BadRequest();
            }

            var sections = _mapper.Map<Section>(createSectionRequest);
            await _sectionService.AddAsync(sections);

            var sectionDto = _mapper.Map<SectionResponseDto>(sections);
            return CreatedAtAction(nameof(GetSectionById), new { id = sections.SectionId }, sectionDto);
        }

        // PUT api/<SectionController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSection(int id,CreateSectionDto updateSectionRequest)
        {
            if (updateSectionRequest == null)
            {
                return BadRequest();
            }

            var section = await _sectionService.GetByIdAsync(id);
            if (section == null)
            {
                return NotFound();
            }

            _mapper.Map(updateSectionRequest, section);
            await _sectionService.UpdateAsync(section);
            var sectionDto = _mapper.Map<SectionResponseDto>(section);
            return Ok(sectionDto);
        }

        // DELETE api/<SectionController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSection(int id)
        {
            var section = await _sectionService.GetByIdAsync(id);
            if (section == null)
            {
                return NotFound();
            }
            await _sectionService.DeleteAsync(id);
            return NoContent();
        }
    }
}
