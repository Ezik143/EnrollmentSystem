using AutoMapper;
using EnrollmentManagementSystemAPI.Models.Dto.Request;
using EnrollmentManagementSystemAPI.Models.Dto.Response;
using EnrollmentManagementSystemAPI.Models.Entities;

namespace EnrollmentManagementSystemAPI.Models.Dto.Profiles
{
    public class StudentProfile : Profile
    {
        public StudentProfile() 
        {
            CreateMap<CreateStudentDto, Student>().ReverseMap();
            CreateMap<StudentResponseDto, Student>().ReverseMap();
        }
    }
}
