using EnrollmentManagementSystemAPI.Models.Entities;

namespace EnrollmentManagementSystemAPI.Models.Dto.Request
{
    public class CreateSectionDto
    {
        public int SectionId { get; set; }
        public int InstructorId { get; set; }
        public int CourseId { get; set; }
        public int CourseSubjectId { get; set; }
        public int TermId { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
