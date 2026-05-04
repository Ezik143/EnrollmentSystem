using AutoMapper;
using EnrollmentManagementSystemAPI.Models.Dto.Request;
using EnrollmentManagementSystemAPI.Models.Dto.Response;
using EnrollmentManagementSystemAPI.Models.Entities;

namespace EnrollmentManagementSystemAPI.Models.Dto.Profiles
{
    public class CourseSubjectProfile : Profile
    {
        public CourseSubjectProfile()
        {
            CreateMap<CreateCourseSubjectDto, CourseSubject>().ReverseMap();
            CreateMap<CourseSubjectResponseDto, CourseSubject>().ReverseMap();
        }
    }
}
