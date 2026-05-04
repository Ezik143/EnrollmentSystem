using System.ComponentModel.DataAnnotations;

namespace EnrollmentManagementSystemAPI.Models.Dto.Request
{
    public class CreateCourseSubjectDto
    {
        [Required, Range(1, int.MaxValue)]
        public int CourseId { get; set; }

        [Required, Range(1, int.MaxValue)]
        public int SubjectId { get; set; }

        [Required, Range(1, 12)]
        public int YearLevel { get; set; }

        [Required, Range(1, 4)]
        public int TermNumber { get; set; }

        [Required]
        public bool IsRequired { get; set; } = true;

        [StringLength(250)]
        public string Remarks { get; set; } = string.Empty;
    }
}
