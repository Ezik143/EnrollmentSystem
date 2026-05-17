using EnrollmentManagementSystemAPI.Models.Dto.Request;
using EnrollmentManagementSystemAPI.Models.Dto.Response;
using EnrollmentManagementSystemAPI.Models.Entities;

namespace EnrollmentManagementSystemAPI.Services.Interfaces
{
    public interface ISubjectService
    {
        Task<IEnumerable<SubjectResponseDto>> GetAllSubjectsAsync();
        Task<SubjectResponseDto?> GetSubjectByIdAsync(int id);
        Task<SubjectResponseDto> CreateSubjectAsync(CreateSubjectDto createSubjectDto);
        Task<SubjectResponseDto> UpdateSubjectAsync(int id, CreateSubjectDto updateSubjectDto);
        Task<bool> DeleteSubjectAsync(int id);
    }
}
