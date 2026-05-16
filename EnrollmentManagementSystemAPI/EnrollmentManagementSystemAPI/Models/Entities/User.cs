namespace EnrollmentManagementSystemAPI.Models.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string PasswordHash { get; set; } = null!;
    }
}
