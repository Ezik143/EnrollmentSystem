using EnrollmentManagementSystemAPI.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace EnrollmentManagementSystemAPI.Models.Dto.Request
{
    public class CreateDepartmentDto
    {
        [Required, StringLength(30)]
        public string DepartmentCode { get; set; } = string.Empty;

        [Required, StringLength(150)]
        public string Name { get; set; } = string.Empty;

        [Required]
        public EducationAuthority EducationAuthority { get; set; } = EducationAuthority.CHED;

        [StringLength(150)]
        public string Campus { get; set; } = string.Empty;

        public bool IsActive { get; set; } = true;
    }
}
