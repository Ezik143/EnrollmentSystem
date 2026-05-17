using EnrollmentManagementSystemAPI.Models.Enums;
using Microsoft.AspNetCore.Identity;

namespace EnrollmentManagementSystemAPI.Models.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public Role Role { get; set; } = Role.Student;
    }
}
