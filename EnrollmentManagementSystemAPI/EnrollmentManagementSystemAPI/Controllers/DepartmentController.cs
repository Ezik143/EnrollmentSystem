using EnrollmentManagementSystemAPI.data;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using EnrollmentManagementSystemAPI.Models.Dto.Request;
using EnrollmentManagementSystemAPI.Models.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EnrollmentManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly AutoMapper.IMapper _mapper;

        public DepartmentController(ApplicationDbContext context, IMapper mapper)
        { 
            _context = context;
            _mapper = mapper;
        }
        // GET: api/<DepartmentController>
        [HttpGet]
        public IActionResult GetAllDepartment() 
        {
            var Departments = _context.Departments.ToList();
            var departmentDtos = _mapper.Map<List<DepartmentDto>>(Departments);
            return Ok(departmentDtos);
        }

        // GET api/<DepartmentController>/5
        [HttpGet("{id}")]
        public IActionResult GetDepartmentById(int id)
        {
            var department = _context.Departments.Find(id);
            if (department == null)
            {
                return NotFound();
            }
            var departmentDto = _mapper.Map<DepartmentDto>(department);
            return Ok(departmentDto);
        }

        // POST api/<DepartmentController>
        [HttpPost]
        public IActionResult CreateDepartment([FromBody] DepartmentDto departmentDto)
        {
            if (departmentDto == null)
            {
                return BadRequest();
            }
            var department = _mapper.Map<Department>(departmentDto);
            _context.Departments.Add(department);
            _context.SaveChanges();
            return Ok(department);
        }

            // PUT api/<DepartmentController>/5
            [HttpPut("{id}")]
        public IActionResult UpdateDepartment(int id, [FromBody] DepartmentDto updateDepartment)
        {
            if (updateDepartment == null)
            {  
                return BadRequest(); 
            }
             
            var department = _context.Departments.Find(id);

            if(department == null)
            {
                return NotFound();
            }
            _mapper.Map(updateDepartment, department);

            _context.SaveChanges();
            return Ok(department);
        }

        // DELETE api/<DepartmentController>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteDepartment(int id)
        {
            var department = _context.Departments.Find(id);
            if(department == null)
            {
                return NotFound();
            }

            _context.Departments.Remove(department);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
