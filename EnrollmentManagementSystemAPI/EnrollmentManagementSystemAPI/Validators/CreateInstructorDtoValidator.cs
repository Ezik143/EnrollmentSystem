using EnrollmentManagementSystemAPI.Models.Dto.Request;
using FluentValidation;

namespace EnrollmentManagementSystemAPI.Validators
{
    public class CreateInstructorDtoValidator : AbstractValidator<CreateInstructorDto>
    {
        public CreateInstructorDtoValidator()
        {
            RuleFor(x => x.DepartmentId)
                .GreaterThan(0).WithMessage("Department ID must be greater than 0.");
            RuleFor(x => x.EmployeeNumber)
                .NotEmpty().WithMessage("Employee number is required.")
                .MaximumLength(30).WithMessage("Employee number cannot exceed 30 characters.");

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

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Email format is invalid.")
                .MaximumLength(100).WithMessage("Email cannot exceed 100 characters.");

            RuleFor(x => x.Rank)
                .MaximumLength(100).WithMessage("Rank cannot exceed 100 characters.");

            RuleFor(x => x.EmploymentType)
                .MaximumLength(50).WithMessage("Employment type cannot exceed 50 characters.");

            RuleFor(x => x.ContactNumber)
                .MaximumLength(30).WithMessage("Contact number cannot exceed 30 characters.");

            RuleFor(x => x.HireDate)
                .NotEmpty().WithMessage("Hire date is required.");
        }
    }
}
