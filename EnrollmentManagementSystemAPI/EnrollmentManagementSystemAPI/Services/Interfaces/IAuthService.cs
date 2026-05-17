using EnrollmentManagementSystemAPI.Models.Dto.Request;
using EnrollmentManagementSystemAPI.Models.Entities;

namespace EnrollmentManagementSystemAPI.Services.Interfaces
{
    public interface IAuthService
    {
        Task<ApplicationUser> RegisterStudentAsync(CreateStudentDto request);
        Task<ApplicationUser> RegisterInstructorAsync(CreateInstructorDto request);
    }
}
