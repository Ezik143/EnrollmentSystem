using EnrollmentManagementSystemAPI.Models.Enums;

namespace EnrollmentManagementSystemAPI.Models.Dto.Response
{
    public class CourseResponseDto
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; } = string.Empty;
        public string CourseCode { get; set; } = string.Empty;
        public int TotalUnits { get; set; }
        public string Description { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public int DepartmentId { get; set; }
        public EducationLevel EducationLevel { get; set; }
        public int YearDuration { get; set; }
        public string CurriculumYear { get; set; } = string.Empty;
        public string? ChedProgramCode { get; set; }
        public string? SeniorHighTrack { get; set; }
        public string? SeniorHighStrand { get; set; }
    }
}
