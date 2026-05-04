using EnrollmentManagementSystemAPI.Models.Enums;

namespace EnrollmentManagementSystemAPI.Models.Entities
{
    public class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; } = string.Empty;
        public string CourseCode { get; set; } = string.Empty;
        public int TotalUnits { get; set; }
        public string Description { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
        public int DepartmentId { get; set; }
        public Department? Department { get; set; }
        public EducationLevel EducationLevel { get; set; } = EducationLevel.Undergraduate;
        public int YearDuration { get; set; } = 4;
        public string CurriculumYear { get; set; } = string.Empty;
        public string? ChedProgramCode { get; set; }
        public string? SeniorHighTrack { get; set; }
        public string? SeniorHighStrand { get; set; }

        public ICollection<Student> Students { get; set; } = new List<Student>();
        public ICollection<CourseSubject> CourseSubjects { get; set; } = new List<CourseSubject>();
    }
}
