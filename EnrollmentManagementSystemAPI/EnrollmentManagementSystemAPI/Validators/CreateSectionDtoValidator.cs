using EnrollmentManagementSystemAPI.Models.Dto.Request;
using FluentValidation;

namespace EnrollmentManagementSystemAPI.Validators
{
    public class CreateSectionDtoValidator : AbstractValidator<CreateSectionDto>
    {
        public CreateSectionDtoValidator()
        {
            RuleFor(x => x.InstructorId)
                .GreaterThan(0).WithMessage("Instructor ID must be greater than 0.");

            RuleFor(x => x.CourseId)
                .GreaterThan(0).WithMessage("Course ID must be greater than 0.");

            RuleFor(x => x.CourseSubjectId)
                .GreaterThan(0).WithMessage("Course subject ID must be greater than 0.");

            RuleFor(x => x.TermId)
                .GreaterThan(0).WithMessage("Term ID must be greater than 0.");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Section name is required.")
                .MaximumLength(50).WithMessage("Section name cannot exceed 50 characters.");


            RuleFor(x => x.Capacity)
                .GreaterThan(0).WithMessage("Capacity must be greater than 0.")
                .LessThanOrEqualTo(50).WithMessage("Capacity cannot exceed 50.");
        }
    }
}
