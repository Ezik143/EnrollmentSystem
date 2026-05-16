namespace EnrollmentManagementSystemAPI.Models.Dto.Request
{
    public class CreateSectionDto
    {
        public int InstructorId { get; set; }

        public int CourseId { get; set; }

        public int CourseSubjectId { get; set; }

        public int TermId { get; set; }

        public int Capacity { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Room { get; set; } = string.Empty;

        public string Schedule { get; set; } = string.Empty;

        public string Campus { get; set; } = string.Empty;

        public int YearLevel { get; set; }

        public bool IsOpen { get; set; } = true;
    }
}
