using EnrollmentManagementSystemAPI.data;
using EnrollmentManagementSystemAPI.Models.Dto.Request;
using EnrollmentManagementSystemAPI.Models.Entities;
using EnrollmentManagementSystemAPI.Models.Enums;
using EnrollmentManagementSystemAPI.Services.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Identity;

namespace EnrollmentManagementSystemAPI.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly ApplicationDbContext _context;
        private readonly ApplicationUser _user;
        private readonly IValidator<CreateStudentDto> _studentValidator;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AuthService(ApplicationDbContext context, ApplicationUser user, IValidator<CreateStudentDto> studentValidator, UserManager<ApplicationUser> userManager, IConfiguration configuration, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _user = user;
            _studentValidator = studentValidator;
            _userManager = userManager;
            _configuration = configuration;
            _roleManager = roleManager;
        }

        public Task<ApplicationUser> RegisterInstructorAsync(CreateInstructorDto request)
        {
            throw new NotImplementedException();
        }

        public async Task<ApplicationUser> RegisterStudentAsync(CreateStudentDto request)
        {
            var userExist = await _userManager.FindByEmailAsync(request.Email);

            if (userExist != null)
            {
                throw new InvalidOperationException("User already exists");
            }

            ApplicationUser user = new ApplicationUser
            {
                Email = request.Email,
                UserName = request.Email,
                PhoneNumber = request.PhoneNumber,
                Role = Role.Student
            };

            var result = await _userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
            {
                throw new InvalidOperationException("Failed to create user");
            }

            return user;
        }
    }
}
