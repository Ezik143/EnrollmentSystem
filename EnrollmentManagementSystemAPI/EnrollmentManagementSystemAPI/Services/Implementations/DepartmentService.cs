using EnrollmentManagementSystemAPI.Models.Entities;
using EnrollmentManagementSystemAPI.Services.Interfaces;

namespace EnrollmentManagementSystemAPI.Services.Implementations
{
    public class DepartmentService : GenericService<Department>, IDepartmentService
    {
        public DepartmentService(IGenericRepository<Department> repository)
            : base(repository)
        {
        }
    }
}
