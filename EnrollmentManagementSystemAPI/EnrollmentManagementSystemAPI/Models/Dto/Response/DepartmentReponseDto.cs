using EnrollmentManagementSystemAPI.Models.Enums;

namespace EnrollmentManagementSystemAPI.Models.Dto.Response
{
    public class DepartmentReponseDto
    {
        public int DepartmentId { get; set; }
        public string DepartmentCode { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public EducationAuthority EducationAuthority { get; set; }
        public string Campus { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
}
