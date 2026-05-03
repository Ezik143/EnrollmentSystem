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
    public class SectionController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public SectionController(ApplicationDbContext context, IMapper mapper) 
        {
            _context = context;
            _mapper = mapper;
        }
        // GET: api/<SectionController>
        [HttpGet]
        public IActionResult GetSectionById()
        {
            var sections = _context.Sections.ToList();
            var sectionDtos = _mapper.Map<List<SectionResponseDto>>(sections);
            return Ok(sectionDtos);
        }

        // GET api/<SectionController>/5
        [HttpGet("{id}")]
        public IActionResult GetSectionById(int id)
        {
            var section = _context.Sections.Find(id);
            if(section == null)
            {
                return NotFound();
            }

            var sectionDto = _mapper.Map<SectionResponseDto>(section);
            return Ok(sectionDto);
        }

        // POST api/<SectionController>
        [HttpPost]
        public IActionResult CreateSection([FromBody] CreateSectionDto createSectionRequest)
        {
            if (createSectionRequest == null)
            {
                return BadRequest();
            }

            var sections = _mapper.Map<Section>(createSectionRequest);
            _context.Sections.Add(sections);
            _context.SaveChanges();
            
            var sectionDto = _mapper.Map<SectionResponseDto>(sections);
            return CreatedAtAction(nameof(GetSectionById), new { id = sectionDto.SectionId }, sectionDto);
        }

        // PUT api/<SectionController>/5
        [HttpPut("{id}")]
        public IActionResult UpdateSection(int id, [FromBody] CreateSectionDto updateSectionRequest)
        {
            var Section = _context.Sections.Find(id);
            if (Section == null)
            {
                return NotFound();
            }
            var UpdateSection = _mapper.Map(updateSectionRequest, Section);
            _context.SaveChanges();
            var sectionDto = _mapper.Map<SectionResponseDto>(UpdateSection);
            return Ok(sectionDto);
        }

        // DELETE api/<SectionController>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteSection(int id)
        {
            var section = _context.Sections.Find(id);
            if (section == null)
            {
                return NotFound();
            }
            _context.Sections.Remove(section);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
