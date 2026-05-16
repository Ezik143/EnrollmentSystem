using EnrollmentManagementSystemAPI.Models.Enums;

namespace EnrollmentManagementSystemAPI.Models.Dto.Request
{
    public class CreateDepartmentDto
    {
        public string DepartmentCode { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public EducationAuthority EducationAuthority { get; set; } = EducationAuthority.CHED;

        public string Campus { get; set; } = string.Empty;

        public bool IsActive { get; set; } = true;
    }
}
