using EnrollmentManagementSystemAPI.Models.Enums;

namespace EnrollmentManagementSystemAPI.Models.Dto.Request
{
    public class CreateStudentDto
    {
        public int DepartmentId { get; set; }

        public int? CourseId { get; set; }

        public string StudentNumber { get; set; } = string.Empty;

        public string? LearnerReferenceNumber { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string MiddleName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string Suffix { get; set; } = string.Empty;

        public DateOnly DateOfBirth { get; set; }

        public Sex Sex { get; set; }

        public string CivilStatus { get; set; } = string.Empty;

        public string Citizenship { get; set; } = string.Empty;

        public string BirthPlace { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;

        public string HouseStreet { get; set; } = string.Empty;

        public string Barangay { get; set; } = string.Empty;

        public string CityMunicipality { get; set; } = string.Empty;

        public string Province { get; set; } = string.Empty;

        public string Region { get; set; } = string.Empty;

        public string PostalCode { get; set; } = string.Empty;

        public string GuardianName { get; set; } = string.Empty;

        public string GuardianRelationship { get; set; } = string.Empty;

        public string GuardianContactNumber { get; set; } = string.Empty;

        public AdmissionType AdmissionType { get; set; } = AdmissionType.Continuing;

        public EducationLevel EducationLevel { get; set; } = EducationLevel.Undergraduate;

        public string SeniorHighTrack { get; set; } = string.Empty;

        public string SeniorHighStrand { get; set; } = string.Empty;

        public int YearLevel { get; set; }

        public DateOnly DateAdmitted { get; set; }

        public bool IsFourPsBeneficiary { get; set; }
        public bool IsIndigenousPeople { get; set; }

        public string IndigenousGroup { get; set; } = string.Empty;

        public bool IsActive { get; set; } = true;
    }
}
