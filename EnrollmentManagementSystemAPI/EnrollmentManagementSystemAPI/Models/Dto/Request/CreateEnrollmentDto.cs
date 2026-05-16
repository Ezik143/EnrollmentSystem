using EnrollmentManagementSystemAPI.Models.Enums;

namespace EnrollmentManagementSystemAPI.Models.Dto.Request
{
    public class CreateEnrollmentDto
    {
        public int StudentId { get; set; }

        public int SectionId { get; set; }

        public DateOnly EnrolledOn { get; set; }

        public EnrollmentStatus Status { get; set; } = EnrollmentStatus.Pending;

        public int UnitsEnrolled { get; set; }

        public string ScholarshipType { get; set; } = string.Empty;

        public string Remarks { get; set; } = string.Empty;
    }
}
