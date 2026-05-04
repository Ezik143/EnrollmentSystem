using System.ComponentModel.DataAnnotations;

namespace EnrollmentManagementSystemAPI.Models.Dto.Request
{
    public class CreateInstructorDto
    {
        [Required, Range(1, int.MaxValue)]
        public int DepartmentId { get; set; }

        [Required, StringLength(30)]
        public string EmployeeNumber { get; set; } = string.Empty;

        [Required, MaxLength(50)]
        public string FirstName { get; set; } = string.Empty;

        [MaxLength(50)]
        public string MiddleName { get; set; } = string.Empty;

        [Required, MaxLength(50)]
        public string LastName { get; set; } = string.Empty;

        [MaxLength(15)]
        public string Suffix { get; set; } = string.Empty;

        [Required, EmailAddress, MaxLength(100)]
        public string Email { get; set; } = string.Empty;

        [StringLength(100)]
        public string Rank { get; set; } = string.Empty;

        [StringLength(50)]
        public string EmploymentType { get; set; } = string.Empty;

        [StringLength(30)]
        public string ContactNumber { get; set; } = string.Empty;

        [Required, DataType(DataType.Date)]
        public DateOnly HireDate { get; set; }

        [Required]
        public bool IsActive { get; set; } = true;
    }
}
