using AutoMapper;
using EnrollmentManagementSystemAPI.Models.Dto.Request;
using EnrollmentManagementSystemAPI.Models.Dto.Response;
using EnrollmentManagementSystemAPI.Models.Entities;

namespace EnrollmentManagementSystemAPI.Models.Dto.Profiles
{
    public class DepartmentProfile : Profile
    {
        public DepartmentProfile() { 
            CreateMap<CreateDepartmentDto, Department>().ReverseMap();
            CreateMap<DepartmentReponseDto, Department>().ReverseMap();
        }
    }
}
