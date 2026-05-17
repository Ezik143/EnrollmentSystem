using EnrollmentManagementSystemAPI.Models.Dto.Request;
using EnrollmentManagementSystemAPI.Models.Dto.Response;
using EnrollmentManagementSystemAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EnrollmentManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        // GET: api/<DepartmentController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DepartmentReponseDto>>> GetAllDepartment()
        {
            var departments = await _departmentService.GetAllDepartmentsAsync();
            return Ok(departments);
        }

        // GET api/<DepartmentController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DepartmentReponseDto>> GetDepartmentById(int id)
        {
            var department = await _departmentService.GetDepartmentByIdAsync(id);
            if (department == null)
            {
                return NotFound();
            }
            return Ok(department);
        }

        // POST api/<DepartmentController>
        [HttpPost]
        public async Task<ActionResult<DepartmentReponseDto>> CreateDepartment([FromBody] CreateDepartmentDto createDepartmentDto)
        {
            try
            {
                var departmentDto = await _departmentService.CreateDepartmentAsync(createDepartmentDto);
                return CreatedAtAction(nameof(GetDepartmentById), new { id = departmentDto.DepartmentId }, departmentDto);
            }
            catch
            {
                return BadRequest();
            }
        }

        // PUT api/<DepartmentController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<DepartmentReponseDto>> UpdateDepartment(int id, [FromBody] CreateDepartmentDto updateDepartmentDto)
        {
            try
            {
                var departmentDto = await _departmentService.UpdateDepartmentAsync(id, updateDepartmentDto);
                return Ok(departmentDto);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        // DELETE api/<DepartmentController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            try
            {
                await _departmentService.DeleteDepartmentAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
