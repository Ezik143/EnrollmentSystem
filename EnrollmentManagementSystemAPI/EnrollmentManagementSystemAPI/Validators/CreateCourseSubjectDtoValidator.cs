using EnrollmentManagementSystemAPI.Models.Dto.Request;
using FluentValidation;

namespace EnrollmentManagementSystemAPI.Validators
{
    public class CreateCourseSubjectDtoValidator : AbstractValidator<CreateCourseSubjectDto>
    {
        public CreateCourseSubjectDtoValidator()
        {
            RuleFor(x => x.CourseId)
                .GreaterThan(0).WithMessage("Course ID must be greater than 0.");
            RuleFor(x => x.SubjectId)
                .GreaterThan(0).WithMessage("Subject ID must be greater than 0.");
            RuleFor(x => x.YearLevel)
                .InclusiveBetween(1, 12).WithMessage("Year level must be between 1 and 12.");
            RuleFor(x => x.TermNumber)
                .InclusiveBetween(1, 4).WithMessage("Term number must be between 1 and 4.");
            RuleFor(x => x.Remarks)
                .MaximumLength(250).WithMessage("Remarks cannot exceed 250 characters.");
        }
    }
}
