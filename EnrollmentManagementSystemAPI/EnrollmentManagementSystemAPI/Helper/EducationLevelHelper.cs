using EnrollmentManagementSystemAPI.Models.Enums;

namespace EnrollmentManagementSystemAPI.Helper
{
    public static class EducationLevelHelper
    {
        public static (int Min, int Max) GetLevel(EducationLevel level) => level switch
        {
            EducationLevel.Kindergarten => (1, 1),
            EducationLevel.Elementary => (1, 6),
            EducationLevel.JuniorHighSchool => (7, 10),
            EducationLevel.SeniorHighSchool => (11, 12),
            EducationLevel.Undergraduate => (1, 5),
            EducationLevel.Graduate => (1, 3),
            EducationLevel.TechnicalVocational => (1, 4),
            _ => throw new ArgumentOutOfRangeException(nameof(level), $"Not expected education level value: {level}")
        };
    }
}
