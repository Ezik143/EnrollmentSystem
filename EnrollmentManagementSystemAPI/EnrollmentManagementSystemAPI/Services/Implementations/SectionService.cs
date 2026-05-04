using EnrollmentManagementSystemAPI.Models.Entities;
using EnrollmentManagementSystemAPI.Services.Interfaces;

namespace EnrollmentManagementSystemAPI.Services.Implementations
{
    public class SectionService : GenericService<Section>, ISectionService
    {
        public SectionService(IGenericRepository<Section> repository)
            : base(repository)
        {
        }
    }
}
