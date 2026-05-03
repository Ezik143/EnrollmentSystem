using System.ComponentModel.DataAnnotations;

namespace EnrollmentManagementSystemAPI.Models.Dto.Request
{
    public class CreateDepartmentDto
    {
        [Required, StringLength(50)]
        public string DepartmentCode { get; set; } = string.Empty;
        [Required, StringLength(100)]
        public string Name { get; set; } = string.Empty;
    }
}
