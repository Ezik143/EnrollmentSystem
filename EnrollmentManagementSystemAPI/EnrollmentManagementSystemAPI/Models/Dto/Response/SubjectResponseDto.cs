using EnrollmentManagementSystemAPI.Models.Entities;

namespace EnrollmentManagementSystemAPI.Models.Dto.Response
{
    public class SubjectResponseDto
    {
        public int SubjectId { get; set; }
        public int DepartmentId { get; set; }
        public string SubjectCode { get; set; } = string.Empty;
        public string CourseCode { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public int Units { get; set; }
    }
}
