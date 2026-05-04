using EnrollmentManagementSystemAPI.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace EnrollmentManagementSystemAPI.Models.Dto.Request
{
    public class CreateCourseDto
    {
        [Required, StringLength(150)]
        public string CourseName { get; set; } = string.Empty;

        [Required, StringLength(30)]
        public string CourseCode { get; set; } = string.Empty;

        [Required, Range(1, 300)]
        public int TotalUnits { get; set; }

        [Required, StringLength(500)]
        public string Description { get; set; } = string.Empty;

        [Required]
        public bool IsActive { get; set; } = true;

        [Required, Range(1, int.MaxValue)]
        public int DepartmentId { get; set; }

        [Required]
        public EducationLevel EducationLevel { get; set; } = EducationLevel.Undergraduate;

        [Required, Range(1, 12)]
        public int YearDuration { get; set; } = 4;

        [Required, StringLength(20)]
        public string CurriculumYear { get; set; } = string.Empty;

        [StringLength(30)]
        public string? ChedProgramCode { get; set; }

        [StringLength(50)]
        public string? SeniorHighTrack { get; set; }

        [StringLength(50)]
        public string? SeniorHighStrand { get; set; }
    }
}
