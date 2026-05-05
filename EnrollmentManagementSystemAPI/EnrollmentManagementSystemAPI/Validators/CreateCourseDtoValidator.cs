using EnrollmentManagementSystemAPI.Models.Dto.Request;
using FluentValidation;

namespace EnrollmentManagementSystemAPI.Validators
{
    public class CreateCourseDtoValidator : AbstractValidator<CreateCourseDto>
    {
        public CreateCourseDtoValidator() 
        {
            RuleFor(x => x.CourseName)
                .NotEmpty().WithMessage("Course name is required.")
                .MaximumLength(150).WithMessage("Course name cannot exceed 150 characters.");
            RuleFor(x => x.CourseCode)
                .NotEmpty().WithMessage("Course code is required.")
                .MaximumLength(30).WithMessage("Course code cannot exceed 30 characters.");
            RuleFor(x => x.TotalUnits)
                .InclusiveBetween(1, 300).WithMessage("Total units must be between 1 and 300.");
            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description is required.")
                .MaximumLength(500).WithMessage("Description cannot exceed 500 characters.");
            RuleFor(x => x.DepartmentId)
                .GreaterThan(0).WithMessage("Department ID must be greater than 0.");
            RuleFor(x => x.YearDuration)
                .InclusiveBetween(1, 12).WithMessage("Year duration must be between 1 and 12.");
            RuleFor(x => x.CurriculumYear)
                .NotEmpty().WithMessage("Curriculum year is required.")
                .MaximumLength(20).WithMessage("Curriculum year cannot exceed 20 characters.");
            RuleFor(x => x.ChedProgramCode)
                .MaximumLength(30).WithMessage("CHED program code cannot exceed 30 characters.")
                .When(x => !string.IsNullOrEmpty(x.ChedProgramCode));
            RuleFor(x => x.SeniorHighTrack)
                .MaximumLength(50).WithMessage("Senior high track cannot exceed 50 characters.")
                .When(x => !string.IsNullOrEmpty(x.SeniorHighTrack));
            RuleFor(x => x.SeniorHighStrand)
                .MaximumLength(50).WithMessage("Senior high strand cannot exceed 50 characters.")
                .When(x => !string.IsNullOrEmpty(x.SeniorHighStrand));
        }
    }
}
