using EnrollmentManagementSystemAPI.Models.Dto.Request;
using EnrollmentManagementSystemAPI.Models.Dto.Response;
using EnrollmentManagementSystemAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EnrollmentManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _auth;
        public AuthController(IAuthService auth)
        {
            _auth = auth;
        }





        [HttpPost("RegisterInstructor")]

        public async Task<IActionResult> RegisterInstructor(CreateInstructorDto request)
        {
            try
            {
                var result = await _auth.RegisterInstructorAsync(request);
                return CreatedAtAction(nameof(RegisterInstructor), new { id = result.Id }, result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }



        [HttpPost("RegisterStudent")]
        public async Task<IActionResult> RegisterStudent(CreateStudentDto request)
        {
            try
            {
                var result = await _auth.RegisterStudentAsync(request);
                return CreatedAtAction(nameof(RegisterStudent), new { id = result.Id }, result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }


        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDto request)
        {
            try
            {
                var result = await _auth.LoginAsync(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}
