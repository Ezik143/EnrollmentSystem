using EnrollmentManagementSystemAPI.Models.Entities;
using EnrollmentManagementSystemAPI.Services.Interfaces;

namespace EnrollmentManagementSystemAPI.Services.Implementations
{
    public class CourseSubjectService : GenericService<CourseSubject>, ICourseSubjectService
    {
        public CourseSubjectService(IGenericRepository<CourseSubject> repository)
            : base(repository)
        {
        }
    }
}
