using EnrollmentManagementSystemAPI.Models.Entities;
using EnrollmentManagementSystemAPI.Services.Interfaces;

namespace EnrollmentManagementSystemAPI.Services.Implementations
{
    public class EnrollmentService : GenericService<Enrollment>, IEnrollmentService
    {
        public EnrollmentService(IGenericRepository<Enrollment> repository)
            : base(repository)
        {
        }
    }
}
