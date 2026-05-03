namespace EnrollmentManagementSystemAPI.Models.Entities
{
    public class Enrollment
    {
        public int EnrollmentId { get; set; }
        public Student? Student { get; set; }
        public Section? Section { get; set; }
        public string EnrolledOn { get; set; } = string.Empty;
    }
}
