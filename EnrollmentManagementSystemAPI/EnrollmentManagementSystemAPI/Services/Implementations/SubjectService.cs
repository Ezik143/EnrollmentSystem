using EnrollmentManagementSystemAPI.Models.Entities;
using EnrollmentManagementSystemAPI.Services.Interfaces;

namespace EnrollmentManagementSystemAPI.Services.Implementations
{
    public class SubjectService : GenericService<Subject>, ISubjectService
    {
        public SubjectService(IGenericRepository<Subject> repository)
            : base(repository)
        {
        }
    }
}
