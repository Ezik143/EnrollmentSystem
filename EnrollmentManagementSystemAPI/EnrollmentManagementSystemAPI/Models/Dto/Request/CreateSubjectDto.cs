using EnrollmentManagementSystemAPI.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace EnrollmentManagementSystemAPI.Models.Dto.Request
{
    public class CreateSubjectDto
    {
        [Required, Range(1, int.MaxValue)]
        public int DepartmentId { get; set; }

        [Required, StringLength(30)]
        public string SubjectCode { get; set; } = string.Empty;

        [Required, StringLength(150)]
        public string Title { get; set; } = string.Empty;

        [Required, Range(0, 10)]
        public int LectureUnits { get; set; }

        [Required, Range(0, 10)]
        public int LaboratoryUnits { get; set; }

        [Required, Range(1, 12)]
        public int Units { get; set; }

        [Required]
        public bool IsCoreSubject { get; set; } = true;

        [Required]
        public EducationLevel EducationLevel { get; set; } = EducationLevel.Undergraduate;

        [Required, Range(1, 12)]
        public int YearLevel { get; set; }

        [Required, Range(1, 4)]
        public int TermNumber { get; set; }

        public int? PrerequisiteSubjectId { get; set; }
    }
}
