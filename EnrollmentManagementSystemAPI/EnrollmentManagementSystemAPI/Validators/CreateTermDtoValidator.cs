using EnrollmentManagementSystemAPI.Models.Dto.Request;
using FluentValidation;

namespace EnrollmentManagementSystemAPI.Validators
{
    public class CreateTermDtoValidator : AbstractValidator<CreateTermDto>
    {
        public CreateTermDtoValidator()
        {
            RuleFor(x => x.TermCode)
                .GreaterThan(0).WithMessage("Term code must be greater than 0.");

            RuleFor(x => x.AcademicYear)
                .NotEmpty().WithMessage("Academic year is required.")
                .MaximumLength(20).WithMessage("Academic year cannot exceed 20 characters.");

            RuleFor(x => x.TermType)
                .IsInEnum().WithMessage("Term type is invalid.");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Term name is required.")

                .MaximumLength(100).WithMessage("Term name cannot exceed 100 characters.");

            RuleFor(x => x.StartDate)
                .NotEmpty().WithMessage("Start date is required.");

            RuleFor(x => x.EndDate)
                .NotEmpty().WithMessage("End date is required.");

            RuleFor(x => x.EnrollmentStartDate)
                .NotEmpty().WithMessage("Enrollment start date is required.");

            RuleFor(x => x.EnrollmentEndDate)
                .NotEmpty().WithMessage("Enrollment end date is required.");
        }
    }
}
