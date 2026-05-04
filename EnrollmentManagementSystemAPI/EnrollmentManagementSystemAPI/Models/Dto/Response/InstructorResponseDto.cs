namespace EnrollmentManagementSystemAPI.Models.Dto.Response
{
    public class InstructorResponseDto
    {
        public int InstructorId { get; set; }
        public int DepartmentId { get; set; }
        public string EmployeeNumber { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Suffix { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Rank { get; set; } = string.Empty;
        public string EmploymentType { get; set; } = string.Empty;
        public string ContactNumber { get; set; } = string.Empty;
        public DateOnly HireDate { get; set; }
        public bool IsActive { get; set; }
    }
}
