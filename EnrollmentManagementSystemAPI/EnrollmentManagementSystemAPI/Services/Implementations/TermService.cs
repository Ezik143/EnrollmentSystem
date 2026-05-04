using EnrollmentManagementSystemAPI.Models.Entities;
using EnrollmentManagementSystemAPI.Services.Interfaces;

namespace EnrollmentManagementSystemAPI.Services.Implementations
{
    public class TermService : GenericService<Term>, ITermService
    {
        public TermService(IGenericRepository<Term> repository)
            : base(repository)
        {
        }
    }
}
