using EnrollmentManagementSystemAPI.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace EnrollmentManagementSystemAPI.Models.Dto.Request
{
    public class CreateCourseSubjectDto
    {
        [Required]
        public int CourseId { get; set; }
        [Required]
        public int SubjectId { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; } = string.Empty;
        [Required, Range(1, 10)]
        public int SemesterNo { get; set; }
    }
}
