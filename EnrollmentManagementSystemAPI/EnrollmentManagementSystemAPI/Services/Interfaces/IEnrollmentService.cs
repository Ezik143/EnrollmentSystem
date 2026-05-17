using EnrollmentManagementSystemAPI.Models.Dto.Request;
using EnrollmentManagementSystemAPI.Models.Dto.Response;
using EnrollmentManagementSystemAPI.Models.Entities;

namespace EnrollmentManagementSystemAPI.Services.Interfaces
{
    public interface IEnrollmentService
    {
        Task<IEnumerable<EnrollmentResponseDto>> GetAllEnrollmentsAsync();
        Task<EnrollmentResponseDto?> GetEnrollmentByIdAsync(int id);
        Task<EnrollmentResponseDto> CreateEnrollmentAsync(CreateEnrollmentDto createEnrollmentDto);
        Task<EnrollmentResponseDto> UpdateEnrollmentAsync(int id, CreateEnrollmentDto updateEnrollmentDto);
        Task<bool> DeleteEnrollmentAsync(int id);
    }
}
