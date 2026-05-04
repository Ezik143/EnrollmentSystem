using EnrollmentManagementSystemAPI.Models.Enums;

namespace EnrollmentManagementSystemAPI.Models.Entities
{
    public class Subject
    {
        public int SubjectId { get; set; }
        public int DepartmentId { get; set; }
        public Department? Department { get; set; }
        public string SubjectCode { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public int LectureUnits { get; set; }
        public int LaboratoryUnits { get; set; }
        public int Units { get; set; }
        public bool IsCoreSubject { get; set; } = true;
        public EducationLevel EducationLevel { get; set; } = EducationLevel.Undergraduate;
        public int YearLevel { get; set; }
        public int TermNumber { get; set; }
        public int? PrerequisiteSubjectId { get; set; }
        public Subject? PrerequisiteSubject { get; set; }

        public ICollection<Subject> DependentSubjects { get; set; } = new List<Subject>();
        public ICollection<CourseSubject> CourseSubjects { get; set; } = new List<CourseSubject>();
    }
}
