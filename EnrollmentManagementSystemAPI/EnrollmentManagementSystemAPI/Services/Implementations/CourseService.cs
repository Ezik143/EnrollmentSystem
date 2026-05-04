using EnrollmentManagementSystemAPI.Models.Entities;
using EnrollmentManagementSystemAPI.Services.Interfaces;

namespace EnrollmentManagementSystemAPI.Services.Implementations
{
    public class CourseService : GenericService<Course>, ICourseService
    {
        public CourseService(IGenericRepository<Course> repository)
            : base(repository)
        {
        }
    }
}
