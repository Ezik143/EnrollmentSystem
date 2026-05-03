using System.ComponentModel.DataAnnotations;

namespace EnrollmentManagementSystemAPI.Models.Dto.Request
{
    public class CreateStudentDto
    {
        [Required]
        public int departmentId { get; set; }
        [Required]
        public int StudentNumber { get; set; }
        [Required, MaxLength(50)]
        public string FirstName { get; set; } = string.Empty;
        [Required, MaxLength(50)]
        public string MiddleName { get; set; } = string.Empty;
        [Required, MaxLength(50)]   
        public string LastName { get; set; } = string.Empty;
        [Required]
        public DateOnly DateOfBirth { get; set; }
        [Required]
        public string Gender { get; set; } = string.Empty;
        [Required, MaxLength(50)]
        public string Email { get; set; } = string.Empty;
        [Required, MaxLength(50)]
        public string PhoneNumber { get; set; } = string.Empty;
        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        [Required]
        public bool IsActive { get; set; } = true;
    }
}
