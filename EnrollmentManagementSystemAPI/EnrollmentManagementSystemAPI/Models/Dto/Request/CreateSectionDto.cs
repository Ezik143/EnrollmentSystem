using System.ComponentModel.DataAnnotations;

namespace EnrollmentManagementSystemAPI.Models.Dto.Request
{
    public class CreateSectionDto
    {
        [Required, Range(1, int.MaxValue)]
        public int InstructorId { get; set; }

        [Required, Range(1, int.MaxValue)]
        public int CourseId { get; set; }

        [Required, Range(1, int.MaxValue)]
        public int CourseSubjectId { get; set; }

        [Required, Range(1, int.MaxValue)]
        public int TermId { get; set; }

        [Required, Range(1, 200)]
        public int Capacity { get; set; }

        [Required, StringLength(50)]
        public string Name { get; set; } = string.Empty;

        [StringLength(50)]
        public string Room { get; set; } = string.Empty;

        [StringLength(120)]
        public string Schedule { get; set; } = string.Empty;

        [StringLength(150)]
        public string Campus { get; set; } = string.Empty;

        [Required, Range(1, 12)]
        public int YearLevel { get; set; }

        public bool IsOpen { get; set; } = true;
    }
}
