using EnrollmentManagementSystemAPI.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace EnrollmentManagementSystemAPI.Models.Dto.Request
{
    public class CreateEnrollmentDto
    {
        [Required]
        public int StudentId { get; set; }
        [Required]
        public int SectionId { get; set; }
        [Required]
        public string EnrolledOn { get; set; } = string.Empty;
    }
}
