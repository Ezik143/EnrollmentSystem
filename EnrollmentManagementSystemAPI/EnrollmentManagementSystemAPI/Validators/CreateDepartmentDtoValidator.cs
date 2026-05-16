using EnrollmentManagementSystemAPI.Models.Dto.Request;
using FluentValidation;

namespace EnrollmentManagementSystemAPI.Validators
{
    public class CreateDepartmentDtoValidator : AbstractValidator<CreateDepartmentDto>
    {
        public CreateDepartmentDtoValidator()
        {
            RuleFor(x => x.DepartmentCode)
                .NotEmpty().WithMessage("Department code is required.")
                .MaximumLength(30).WithMessage("Department code cannot exceed 30 characters.");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Department name is required.")
                .MaximumLength(150).WithMessage("Department name cannot exceed 150 characters.");

            RuleFor(x => x.EducationAuthority)
                .IsInEnum().WithMessage("Education authority is invalid.");

            RuleFor(x => x.Campus)
                .MaximumLength(150).WithMessage("Campus cannot exceed 150 characters.");
        }
    }
}
