using EnrollmentManagementSystemAPI.Models.Dto.Request;
using FluentValidation;

namespace EnrollmentManagementSystemAPI.Validators
{
    public class CreateEnrollmentDtoValidator : AbstractValidator<CreateEnrollmentDto>
    {
        public CreateEnrollmentDtoValidator()
        {
            RuleFor(x => x.StudentId)
                .GreaterThan(0).WithMessage("Student ID must be greater than 0.");

            RuleFor(x => x.SectionId)
                .GreaterThan(0).WithMessage("Section ID must be greater than 0.");

            RuleFor(x => x.EnrolledOn)
                .NotEmpty().WithMessage("Enrollment date is required.");

            RuleFor(x => x.Status)
                .IsInEnum().WithMessage("Enrollment status is invalid.");

            RuleFor(x => x.UnitsEnrolled)
                .InclusiveBetween(1, 60).WithMessage("Units enrolled must be between 1 and 60.");

            RuleFor(x => x.ScholarshipType)
                .MaximumLength(100).WithMessage("Scholarship type cannot exceed 100 characters.");

            RuleFor(x => x.Remarks)
                .MaximumLength(250).WithMessage("Remarks cannot exceed 250 characters.");
        }
    }
}
