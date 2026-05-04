using EnrollmentManagementSystemAPI.Models.Entities;
using EnrollmentManagementSystemAPI.Services.Interfaces;

namespace EnrollmentManagementSystemAPI.Services.Implementations
{
    public class InstructorService : GenericService<Instructor>, IInstructorService
    {
        public InstructorService(IGenericRepository<Instructor> repository)
            : base(repository)
        {
        }
    }
}
