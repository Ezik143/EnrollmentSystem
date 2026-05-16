using EnrollmentManagementSystemAPI.Models.Dto.Request;
using FluentValidation;

namespace EnrollmentManagementSystemAPI.Validators
{
    public class CreateStudentDtoValidator : AbstractValidator<CreateStudentDto>
    {
        public CreateStudentDtoValidator()
        {
            RuleFor(x => x.DepartmentId)
                .GreaterThan(0).WithMessage("Department ID must be greater than 0.");

            RuleFor(x => x.CourseId)
                .GreaterThan(0).WithMessage("Course ID must be greater than 0.")
                .When(x => x.CourseId.HasValue);

            RuleFor(x => x.StudentNumber)
                .NotEmpty().WithMessage("Student number is required.")
                .MaximumLength(30).WithMessage("Student number cannot exceed 30 characters.");

            RuleFor(x => x.LearnerReferenceNumber)
                .Length(12).WithMessage("Learner reference number must be exactly 12 characters.")
                .When(x => x.LearnerReferenceNumber is not null);

            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("First name is required.")
                .MaximumLength(50).WithMessage("First name cannot exceed 50 characters.");

            RuleFor(x => x.MiddleName)
                .MaximumLength(50).WithMessage("Middle name cannot exceed 50 characters.");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Last name is required.")
                .MaximumLength(50).WithMessage("Last name cannot exceed 50 characters.");

            RuleFor(x => x.Suffix)
                .MaximumLength(15).WithMessage("Suffix cannot exceed 15 characters.");

            RuleFor(x => x.DateOfBirth)
                .NotEmpty().WithMessage("Date of birth is required.");

            RuleFor(x => x.Sex)
                .IsInEnum().WithMessage("Sex is invalid.");

            RuleFor(x => x.CivilStatus)
                .IsInEnum().WithMessage("Civil status is invalid.");

            RuleFor(x => x.Citizenship)
                .MaximumLength(60).WithMessage("Citizenship cannot exceed 60 characters.");

            RuleFor(x => x.BirthPlace)
                .MaximumLength(120).WithMessage("Birth place cannot exceed 120 characters.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Email format is invalid.")
                .MaximumLength(100).WithMessage("Email cannot exceed 100 characters.");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("Phone number is required.")
                .MaximumLength(30).WithMessage("Phone number cannot exceed 30 characters.");

            RuleFor(x => x.HouseStreet)
                .MaximumLength(150).WithMessage("House street cannot exceed 150 characters.");

            RuleFor(x => x.Barangay)
                .MaximumLength(100).WithMessage("Barangay cannot exceed 100 characters.");

            RuleFor(x => x.CityMunicipality)
                .MaximumLength(100).WithMessage("City/Municipality cannot exceed 100 characters.");

            RuleFor(x => x.Province)
                .MaximumLength(100).WithMessage("Province cannot exceed 100 characters.");

            RuleFor(x => x.Region)
                .MaximumLength(100).WithMessage("Region cannot exceed 100 characters.");

            RuleFor(x => x.PostalCode)
                .MaximumLength(15).WithMessage("Postal code cannot exceed 15 characters.");

            RuleFor(x => x.GuardianName)
                .MaximumLength(150).WithMessage("Guardian name cannot exceed 150 characters.");

            RuleFor(x => x.GuardianRelationship)
                .MaximumLength(50).WithMessage("Guardian relationship cannot exceed 50 characters.");

            RuleFor(x => x.GuardianContactNumber)
                .MaximumLength(30).WithMessage("Guardian contact number cannot exceed 30 characters.");

            RuleFor(x => x.AdmissionType)
                .IsInEnum().WithMessage("Admission type is invalid.");

            RuleFor(x => x.EducationLevel)
                .IsInEnum().WithMessage("Education level is invalid.");

            RuleFor(x => x.YearLevel)
                .Must((dto, yearLevel) =>
                {
                    var (min, max) = Helper.EducationLevelHelper.GetLevel(dto.EducationLevel);
                    return yearLevel >= min && yearLevel <= max;
                } )
                .WithMessage((dto, yearLevel) =>
                {
                    var (min, max) = Helper.EducationLevelHelper.GetLevel(dto.EducationLevel);
                    return $"Year level must be between {min} and {max}.";
                });

            RuleFor(x => x.DateAdmitted)
                .NotEmpty().WithMessage("Date admitted is required.");
            RuleFor(x => x.IndigenousGroup)
                .MaximumLength(100).WithMessage("Indigenous group cannot exceed 100 characters.");
        }
    }
}
