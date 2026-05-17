using EnrollmentManagementSystemAPI.Models.Enums;

namespace EnrollmentManagementSystemAPI.Models.Dto.Response
{
    public class UserResponseDto
    {
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = null!;
        public Role Role { get; set; } = Role.Student;
    }
}
