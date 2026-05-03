using EnrollmentManagementSystemAPI.Models.Entities;

namespace EnrollmentManagementSystemAPI.Models.Dto.Response
{
    public class CourseSubjectResponseDto
    {
        public int CourseId { get; set; }
        public int SubjectId { get; set; }
        public string Name { get; set; } = string.Empty;
        public int SemesterNo { get; set; }
    }
}
