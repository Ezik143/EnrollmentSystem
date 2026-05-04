using EnrollmentManagementSystemAPI.Models.Enums;

namespace EnrollmentManagementSystemAPI.Models.Dto.Response
{
    public class TermResponseDto
    {
        public int TermId { get; set; }
        public int TermCode { get; set; }
        public string AcademicYear { get; set; } = string.Empty;
        public TermType TermType { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public DateOnly EnrollmentStartDate { get; set; }
        public DateOnly EnrollmentEndDate { get; set; }
        public bool IsCurrent { get; set; }
    }
}
