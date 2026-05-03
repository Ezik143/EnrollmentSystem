using AutoMapper;
using EnrollmentManagementSystemAPI.Models.Dto.Request;
using EnrollmentManagementSystemAPI.Models.Entities;
namespace EnrollmentManagementSystemAPI.Models.Dto.Profiles
{
    public class CourseProfile : Profile
    {
        public CourseProfile() {
            CreateMap<CourseDto, Course>().ReverseMap();
        }
    }
}
