namespace EnrollmentManagementSystemAPI.Models.Entities
{
    public class Instructor
    {
        public int InstructorId { get; set; }
        public Department? Department { get; set; } = null;
        public int EmployeeNumber { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime HireDate { get; set; }
        public bool IsActive { get; set; } = true;

    }
}
