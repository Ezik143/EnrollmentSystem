using AutoMapper;
using EnrollmentManagementSystemAPI.Models.Dto.Request;
using EnrollmentManagementSystemAPI.Models.Dto.Response;
using EnrollmentManagementSystemAPI.Models.Entities;

namespace EnrollmentManagementSystemAPI.Models.Dto.Profiles
{
    public class InstructorProfile : Profile
    {
        public InstructorProfile()
        {
            CreateMap<CreateInstructorDto, Instructor>().ReverseMap();
            CreateMap<InstructorResponseDto, Instructor>();
        }
    }
}
