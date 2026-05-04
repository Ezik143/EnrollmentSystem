using EnrollmentManagementSystemAPI.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace EnrollmentManagementSystemAPI.Models.Dto.Request
{
    public class CreateStudentDto
    {
        [Required, Range(1, int.MaxValue)]
        public int DepartmentId { get; set; }

        public int? CourseId { get; set; }

        [Required, StringLength(30)]
        public string StudentNumber { get; set; } = string.Empty;

        [StringLength(12, MinimumLength = 12)]
        public string? LearnerReferenceNumber { get; set; }

        [Required, StringLength(50)]
        public string FirstName { get; set; } = string.Empty;

        [StringLength(50)]
        public string MiddleName { get; set; } = string.Empty;

        [Required, StringLength(50)]
        public string LastName { get; set; } = string.Empty;

        [StringLength(15)]
        public string Suffix { get; set; } = string.Empty;

        [Required, DataType(DataType.Date)]
        public DateOnly DateOfBirth { get; set; }

        [Required, StringLength(30)]
        public string Gender { get; set; } = string.Empty;

        [StringLength(30)]
        public string CivilStatus { get; set; } = string.Empty;

        [StringLength(60)]
        public string Citizenship { get; set; } = string.Empty;

        [StringLength(120)]
        public string BirthPlace { get; set; } = string.Empty;

        [Required, EmailAddress, StringLength(100)]
        public string Email { get; set; } = string.Empty;

        [Required, StringLength(30)]
        public string PhoneNumber { get; set; } = string.Empty;

        [StringLength(150)]
        public string HouseStreet { get; set; } = string.Empty;

        [StringLength(100)]
        public string Barangay { get; set; } = string.Empty;

        [StringLength(100)]
        public string CityMunicipality { get; set; } = string.Empty;

        [StringLength(100)]
        public string Province { get; set; } = string.Empty;

        [StringLength(100)]
        public string Region { get; set; } = string.Empty;

        [StringLength(15)]
        public string PostalCode { get; set; } = string.Empty;

        [StringLength(150)]
        public string GuardianName { get; set; } = string.Empty;

        [StringLength(50)]
        public string GuardianRelationship { get; set; } = string.Empty;

        [StringLength(30)]
        public string GuardianContactNumber { get; set; } = string.Empty;

        [Required]
        public AdmissionType AdmissionType { get; set; } = AdmissionType.Continuing;

        [Required]
        public EducationLevel EducationLevel { get; set; } = EducationLevel.Undergraduate;

        [StringLength(50)]
        public string SeniorHighTrack { get; set; } = string.Empty;

        [StringLength(50)]
        public string SeniorHighStrand { get; set; } = string.Empty;

        [Required, Range(1, 12)]
        public int YearLevel { get; set; }

        [Required, DataType(DataType.Date)]
        public DateOnly DateAdmitted { get; set; }

        public bool IsFourPsBeneficiary { get; set; }
        public bool IsIndigenousPeople { get; set; }

        [StringLength(100)]
        public string IndigenousGroup { get; set; } = string.Empty;

        public bool IsActive { get; set; } = true;
    }
}
