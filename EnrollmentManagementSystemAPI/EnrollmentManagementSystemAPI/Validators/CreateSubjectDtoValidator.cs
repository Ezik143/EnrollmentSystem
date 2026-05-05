using EnrollmentManagementSystemAPI.Models.Dto.Request;
using FluentValidation;

namespace EnrollmentManagementSystemAPI.Validators
{
    public class CreateSubjectDtoValidator : AbstractValidator<CreateSubjectDto>
    {
        public CreateSubjectDtoValidator()
        {
            RuleFor(x => x.DepartmentId)
                .GreaterThan(0).WithMessage("Department ID must be greater than 0.");
            RuleFor(x => x.SubjectCode)
                .NotEmpty().WithMessage("Subject code is required.")
                .MaximumLength(30).WithMessage("Subject code cannot exceed 30 characters.");
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title is required.")
                .MaximumLength(150).WithMessage("Title cannot exceed 150 characters.");
            RuleFor(x => x.LectureUnits)
                .InclusiveBetween(0, 10).WithMessage("Lecture units must be between 0 and 10.");
            RuleFor(x => x.LaboratoryUnits)
                .InclusiveBetween(0, 10).WithMessage("Laboratory units must be between 0 and 10.");
            RuleFor(x => x.Units)
                .InclusiveBetween(1, 12).WithMessage("Units must be between 1 and 12.");
            RuleFor(x => x.EducationLevel)
                .IsInEnum().WithMessage("Education level is invalid.");
            RuleFor(x => x.YearLevel)
                .InclusiveBetween(1, 12).WithMessage("Year level must be between 1 and 12.");
            RuleFor(x => x.TermNumber)
                .InclusiveBetween(1, 4).WithMessage("Term number must be between 1 and 4.");
            RuleFor(x => x.PrerequisiteSubjectId)
                .GreaterThan(0).WithMessage("Prerequisite subject ID must be greater than 0.")
                .When(x => x.PrerequisiteSubjectId.HasValue);
        }
    }
}
