using AutoMapper;
using EnrollmentManagementSystemAPI.Models.Dto.Request;
using EnrollmentManagementSystemAPI.Models.Entities;

namespace EnrollmentManagementSystemAPI.Models.Dto.Profiles
{
    public class DepartmentProfile : Profile
    {
        public DepartmentProfile() { 
            CreateMap<DepartmentDto, Department>().ReverseMap();
        }
    }
}
