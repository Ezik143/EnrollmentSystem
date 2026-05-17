using EnrollmentManagementSystemAPI.Models.Dto.Request;
using EnrollmentManagementSystemAPI.Models.Dto.Response;
using EnrollmentManagementSystemAPI.Models.Entities;

namespace EnrollmentManagementSystemAPI.Services.Interfaces
{
    public interface ICourseService
    {
        Task<IEnumerable<CourseResponseDto>> GetAllCoursesAsync();
        Task<CourseResponseDto?> GetCourseByIdAsync(int id);
        Task<CourseResponseDto> CreateCourseAsync(CreateCourseDto createCourseDto);
        Task<CourseResponseDto> UpdateCourseAsync(int id, CreateCourseDto updateCourseDto);
        Task<bool> DeleteCourseAsync(int id);
    }
}
