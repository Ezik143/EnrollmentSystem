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
    public class TermController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public TermController(ApplicationDbContext context, IMapper mapper) 
        {
            _context = context;
            _mapper = mapper;
        }
        // GET: api/<TermController>
        [HttpGet]
        public IActionResult GetAllTerm()
        {
            var term = _context.Term.ToList();
            var termDtos = _mapper.Map<List<TermResponseDto>>(term);
            return Ok(termDtos);
        }

        // GET api/<TermController>/5
        [HttpGet("{id}")]
        public IActionResult GetSubjectById(int id)
        {
            var term = _context.Term.Find(id);
            if (term == null)
            {
                return BadRequest();
            }

            var termDto = _mapper.Map<TermResponseDto>(term);
            return Ok(termDto);
        }

        // POST api/<TermController>
        [HttpPost]
        public IActionResult CreateTerm([FromBody] CreateTermDto createTermDto)
        {
            if(createTermDto == null)
            {
                return BadRequest();
            }

            var term = _mapper.Map<Term>(createTermDto);
            _context.Term.Add(term);
            _context.SaveChanges();
            var termDto = _mapper.Map<TermResponseDto>(term);
            return CreatedAtAction(nameof(GetSubjectById), new { id = termDto.TermId }, termDto);
        }

        // PUT api/<TermController>/5
        [HttpPut("{id}")]
        public IActionResult UpdateTerm(int id, [FromBody] CreateCourseDto createCourseDto)
        {
            var term = _context.Term.Find(id);
            if (term == null)
            {
                return NotFound();
            }
            _mapper.Map(createCourseDto, term);
            _context.SaveChanges();
            var termDto = _mapper.Map<TermResponseDto>(term);
            return Ok(termDto);
        }

        // DELETE api/<TermController>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteTerm(int id)
        {
            var term = _context.Term.Find(id);
            if(term == null)
            {
                return NotFound();
            }
            _context.Term.Remove(term);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
