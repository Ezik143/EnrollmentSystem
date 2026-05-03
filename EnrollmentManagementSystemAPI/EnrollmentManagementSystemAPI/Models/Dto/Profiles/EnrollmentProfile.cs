using AutoMapper;
using EnrollmentManagementSystemAPI.Models.Dto.Request;
using EnrollmentManagementSystemAPI.Models.Dto.Response;
using EnrollmentManagementSystemAPI.Models.Entities;

namespace EnrollmentManagementSystemAPI.Models.Dto.Profiles
{
    public class EnrollmentProfile : Profile
    {
        public EnrollmentProfile() 
        {
            CreateMap<CreateEnrollmentDto, Enrollment>().ReverseMap();
            CreateMap<EnrollmentResponseDto, Enrollment>();
        }
    }
}
