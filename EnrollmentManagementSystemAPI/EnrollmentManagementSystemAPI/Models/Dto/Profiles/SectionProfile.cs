using AutoMapper;
using EnrollmentManagementSystemAPI.Models.Dto.Request;
using EnrollmentManagementSystemAPI.Models.Dto.Response;
using EnrollmentManagementSystemAPI.Models.Entities;

namespace EnrollmentManagementSystemAPI.Models.Dto.Profiles
{
    public class SectionProfile : Profile
    {
        public SectionProfile()
        {
            CreateMap<CreateSectionDto, Section>().ReverseMap();
            CreateMap<SectionResponseDto, Section>().ReverseMap();
        }
    }
}
