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
            RuleFor(x => x.Capacity)
                .InclusiveBetween(1, 200).WithMessage("Capacity must be between 1 and 200.");
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Section name is required.")
                .MaximumLength(50).WithMessage("Section name cannot exceed 50 characters.");
            RuleFor(x => x.Room)
                .MaximumLength(50).WithMessage("Room cannot exceed 50 characters.");
            RuleFor(x => x.Schedule)
                .MaximumLength(120).WithMessage("Schedule cannot exceed 120 characters.");
            RuleFor(x => x.Campus)
                .MaximumLength(150).WithMessage("Campus cannot exceed 150 characters.");
            RuleFor(x => x.YearLevel)
                .InclusiveBetween(1, 12).WithMessage("Year level must be between 1 and 12.");
        }
    }
}
