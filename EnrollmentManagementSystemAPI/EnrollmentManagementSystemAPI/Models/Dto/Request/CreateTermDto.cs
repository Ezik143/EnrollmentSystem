using EnrollmentManagementSystemAPI.Models.Enums;

namespace EnrollmentManagementSystemAPI.Models.Dto.Request
{
    public class CreateTermDto
    {
        public int TermCode { get; set; }

        public string AcademicYear { get; set; } = string.Empty;

        public TermType TermType { get; set; } = TermType.FirstSemester;

        public string Name { get; set; } = string.Empty;

        public DateOnly StartDate { get; set; }

        public DateOnly EndDate { get; set; }

        public DateOnly EnrollmentStartDate { get; set; }

        public DateOnly EnrollmentEndDate { get; set; }

        public bool IsCurrent { get; set; }
    }
}
