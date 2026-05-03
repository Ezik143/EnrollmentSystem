using System.ComponentModel.DataAnnotations;

namespace EnrollmentManagementSystemAPI.Models.Dto.Request
{
    public class CreateCourseDto
    {
        [Required, StringLength(100)]
        public string CourseName { get; set; } = string.Empty;
        [Required]
        public string CourseCode { get; set; } = string.Empty;
        [Required, Range(1, 100)]
        public int Credits { get; set; }
        [Required]
        public string Description { get; set; } = string.Empty;
        [Required]
        public bool isActive { get; set; } = true;
        [Required]
        public int DepartmentId { get; set; }
    }
}
