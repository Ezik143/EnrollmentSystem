using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using EnrollmentManagementSystemAPI.Models.Dto.Request;
using EnrollmentManagementSystemAPI.Models.Entities;
using EnrollmentManagementSystemAPI.Models.Dto.Response;
using EnrollmentManagementSystemAPI.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EnrollmentManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;
        private readonly AutoMapper.IMapper _mapper;

        public DepartmentController(IDepartmentService departmentService, IMapper mapper)
        {
            _departmentService = departmentService;
            _mapper = mapper;
        }
        // GET: api/<DepartmentController>
        [HttpGet]
        public async Task<IActionResult> GetAllDepartment()
        {
            var Departments = await _departmentService.GetAllAsync();
            var departmentDtos = _mapper.Map<List<DepartmentReponseDto>>(Departments);
            return Ok(departmentDtos);
        }

        // GET api/<DepartmentController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDepartmentById(int id)
        {
            var department = await _departmentService.GetByIdAsync(id);
            if (department == null)
            {
                return NotFound();
            }
            var departmentDto = _mapper.Map<DepartmentReponseDto>(department);
            return Ok(departmentDto);
        }

        // POST api/<DepartmentController>
        [HttpPost]
        public async Task<IActionResult> CreateDepartment([FromBody] CreateDepartmentDto departmentDto)
        {
            if (departmentDto == null)
            {
                return BadRequest();
            }
            var department = _mapper.Map<Department>(departmentDto);
            await _departmentService.AddAsync(department);

            var createdDepartmentDto = _mapper.Map<CreateDepartmentDto>(department);
            return CreatedAtAction(nameof(GetDepartmentById), new { id = department.DepartmentId }, createdDepartmentDto);
        }

        // PUT api/<DepartmentController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDepartment(int id, [FromBody] CreateDepartmentDto updateDepartment)
        {
            if (updateDepartment == null)
            {
                return BadRequest();
            }

            var department = await _departmentService.GetByIdAsync(id);

            if (department == null)
            {
                return NotFound();
            }
            _mapper.Map(updateDepartment, department);

            await _departmentService.UpdateAsync(department);
            var departmentDto = _mapper.Map<CreateDepartmentDto>(department);
            return Ok(departmentDto);
        }

        // DELETE api/<DepartmentController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            var department = await _departmentService.GetByIdAsync(id);
            if (department == null)
            {
                return NotFound();
            }

            await _departmentService.DeleteAsync(id);
            return NoContent();
        }
    }
}
