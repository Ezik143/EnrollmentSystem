using EnrollmentManagementSystemAPI.Models.Entities;

namespace EnrollmentManagementSystemAPI.Models.Dto.Response
{
    public class InstructorResponseDto
    {
        public int InstructorId { get; set; }
        public int DepartmentId { get; set; }
        public int EmployeeNumber { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime HireDate { get; set; }
        public bool IsActive { get; set; } = true;

    }
}
