namespace EnrollmentManagementSystemAPI.Models.Dto.Response
{
    public class CourseSubjectResponseDto
    {
        public int CourseSubjectId { get; set; }
        public int CourseId { get; set; }
        public int SubjectId { get; set; }
        public int YearLevel { get; set; }
        public int TermNumber { get; set; }
        public bool IsRequired { get; set; }
        public string Remarks { get; set; } = string.Empty;
    }
}
