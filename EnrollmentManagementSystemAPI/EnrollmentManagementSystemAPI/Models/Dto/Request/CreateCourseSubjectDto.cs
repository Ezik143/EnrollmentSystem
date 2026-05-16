namespace EnrollmentManagementSystemAPI.Models.Dto.Request
{
    public class CreateCourseSubjectDto
    {
        public int CourseId { get; set; }

        public int SubjectId { get; set; }

        public int YearLevel { get; set; }

        public int TermNumber { get; set; }

        public bool IsRequired { get; set; } = true;

        public string Remarks { get; set; } = string.Empty;
    }
}
