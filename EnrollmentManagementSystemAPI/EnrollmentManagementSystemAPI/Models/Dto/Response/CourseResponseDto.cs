namespace EnrollmentManagementSystemAPI.Models.Dto.Response
{
    public class CourseResponseDto
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; } = string.Empty;
        public string CourseCode { get; set; } = string.Empty;
        public int Credits { get; set; }
        public string Description { get; set; } = string.Empty;
        public bool isActive { get; set; } = true;
        public int DepartmentId { get; set; }
    }
}
