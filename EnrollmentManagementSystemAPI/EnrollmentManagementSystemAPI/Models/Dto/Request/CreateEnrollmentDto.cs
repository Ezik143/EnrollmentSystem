using EnrollmentManagementSystemAPI.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace EnrollmentManagementSystemAPI.Models.Dto.Request
{
    public class CreateEnrollmentDto
    {
        [Required, Range(1, int.MaxValue)]
        public int StudentId { get; set; }

        [Required, Range(1, int.MaxValue)]
        public int SectionId { get; set; }

        [Required, DataType(DataType.Date)]
        public DateOnly EnrolledOn { get; set; }

        [Required]
        public EnrollmentStatus Status { get; set; } = EnrollmentStatus.Pending;

        [Required, Range(1, 60)]
        public int UnitsEnrolled { get; set; }

        [StringLength(100)]
        public string ScholarshipType { get; set; } = string.Empty;

        [StringLength(250)]
        public string Remarks { get; set; } = string.Empty;
    }
}
