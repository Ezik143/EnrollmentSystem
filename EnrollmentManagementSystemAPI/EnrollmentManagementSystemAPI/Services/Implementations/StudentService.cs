using EnrollmentManagementSystemAPI.Models.Entities;
using EnrollmentManagementSystemAPI.Services.Interfaces;

namespace EnrollmentManagementSystemAPI.Services.Implementations
{
    public class StudentService : GenericService<Student>, IStudentService
    {
        public StudentService(IGenericRepository<Student> repository)
            : base(repository)
        {
        }
    }
}
