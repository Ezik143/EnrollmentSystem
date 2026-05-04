using EnrollmentManagementSystemAPI.Models.Enums;

namespace EnrollmentManagementSystemAPI.Models.Dto.Response
{
    public class EnrollmentResponseDto
    {
        public int EnrollmentId { get; set; }
        public int StudentId { get; set; }
        public int SectionId { get; set; }
        public DateOnly EnrolledOn { get; set; }
        public EnrollmentStatus Status { get; set; }
        public int UnitsEnrolled { get; set; }
        public string ScholarshipType { get; set; } = string.Empty;
        public string Remarks { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
    }
}
