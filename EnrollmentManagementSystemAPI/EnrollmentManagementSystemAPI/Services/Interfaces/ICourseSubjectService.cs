using EnrollmentManagementSystemAPI.Models.Dto.Request;
using EnrollmentManagementSystemAPI.Models.Dto.Response;
using EnrollmentManagementSystemAPI.Models.Entities;

namespace EnrollmentManagementSystemAPI.Services.Interfaces
{
    public interface ICourseSubjectService
    {
        Task<IEnumerable<CourseSubjectResponseDto>> GetAllCourseSubjectsAsync();
        Task<CourseSubjectResponseDto?> GetCourseSubjectByIdAsync(int id);
        Task<CourseSubjectResponseDto> CreateCourseSubjectAsync(CreateCourseSubjectDto createCourseSubjectDto);
        Task<CourseSubjectResponseDto> UpdateCourseSubjectAsync(int id, CreateCourseSubjectDto updateCourseSubjectDto);
        Task<bool> DeleteCourseSubjectAsync(int id);
    }
}
