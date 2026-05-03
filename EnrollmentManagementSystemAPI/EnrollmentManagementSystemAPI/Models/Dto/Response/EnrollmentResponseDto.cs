using EnrollmentManagementSystemAPI.Models.Entities;

namespace EnrollmentManagementSystemAPI.Models.Dto.Response
{
    public class EnrollmentResponseDto
    {
        public int EnrollmentId { get; set; }
        public int StudentId { get; set; }
        public int SectionId { get; set; }
        public string EnrolledOn { get; set; } = string.Empty;
    }
}
