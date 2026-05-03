namespace EnrollmentManagementSystemAPI.Models.Dto.Response
{
    public class TermResponseDto
    {
        public int TermId { get; set; }
        public int TermCode { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public bool IsCurrent { get; set; }
    }
}
