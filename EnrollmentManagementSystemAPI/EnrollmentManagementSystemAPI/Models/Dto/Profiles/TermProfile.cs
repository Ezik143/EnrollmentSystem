using AutoMapper;
using EnrollmentManagementSystemAPI.Models.Dto.Request;
using EnrollmentManagementSystemAPI.Models.Dto.Response;
using EnrollmentManagementSystemAPI.Models.Entities;

namespace EnrollmentManagementSystemAPI.Models.Dto.Profiles
{
    public class TermProfile : Profile
    {
        public TermProfile() 
        {
            CreateMap<CreateTermDto, Term>().ReverseMap();
            CreateMap<TermResponseDto, Term>();
        }
    }
}
