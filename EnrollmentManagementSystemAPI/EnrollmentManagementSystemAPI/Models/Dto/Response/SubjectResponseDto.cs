using EnrollmentManagementSystemAPI.Models.Enums;

namespace EnrollmentManagementSystemAPI.Models.Dto.Response
{
    public class SubjectResponseDto
    {
        public int SubjectId { get; set; }
        public int DepartmentId { get; set; }
        public string SubjectCode { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public int LectureUnits { get; set; }
        public int LaboratoryUnits { get; set; }
        public int Units { get; set; }
        public bool IsCoreSubject { get; set; }
        public EducationLevel EducationLevel { get; set; }
        public int YearLevel { get; set; }
        public int TermNumber { get; set; }
        public int? PrerequisiteSubjectId { get; set; }
    }
}
