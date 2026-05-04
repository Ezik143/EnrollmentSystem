using System.ComponentModel.DataAnnotations;

namespace EnrollmentManagementSystemAPI.Models.Dto.Request
{
    public class CreateSubjectDto
    {
        [Required, Range(1, int.MaxValue)]
        public int SubjectId { get; set; }
        [Required,Range(1, int.MaxValue)]
        public int DepartmentId { get; set; }
        [Required, MaxLength(50)]
        public string SubjectCode { get; set; } = string.Empty;
        [Required, MaxLength(50)]
        public string CourseCode { get; set; } = string.Empty;
        [Required, MaxLength(100)]
        public string Title { get; set; } = string.Empty;
        [Required, Range(1, int.MaxValue)]
        public int Units { get; set; }
    }
}
