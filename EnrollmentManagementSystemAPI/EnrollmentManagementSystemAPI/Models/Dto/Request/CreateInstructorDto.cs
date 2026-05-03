using EnrollmentManagementSystemAPI.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace EnrollmentManagementSystemAPI.Models.Dto.Request
{
    public class CreateInstructorDto
    {
        [Required]
        public int DepartureId { get; set; }
        [Required]
        public int EmployeeNumber { get; set; }
        [Required, MaxLength(50)]
        public string FirstName { get; set; } = string.Empty;
        [Required, MaxLength(50)]
        public string MiddleName { get; set; } = string.Empty;
        [Required, MaxLength(50)]
        public string LastName { get; set; } = string.Empty;
        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required, DataType(DataType.Date)]
        public DateTime HireDate { get; set; }
        [Required]
        public bool IsActive { get; set; } = true;
    }
}
