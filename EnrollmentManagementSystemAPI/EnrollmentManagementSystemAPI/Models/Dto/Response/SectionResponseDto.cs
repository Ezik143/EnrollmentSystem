using EnrollmentManagementSystemAPI.Models.Entities;

namespace EnrollmentManagementSystemAPI.Models.Dto.Response
{
    public class SectionResponseDto
    {
        public int SectionId { get; set; }
        public int InstructorId { get; set; }
        public int CourseId { get; set; }
        public int CourseSubjectId { get; set; }
        public int TermId { get; set; }
        public int Capacity { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
