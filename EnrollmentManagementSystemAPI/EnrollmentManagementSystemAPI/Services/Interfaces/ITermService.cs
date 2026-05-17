using EnrollmentManagementSystemAPI.Models.Dto.Request;
using EnrollmentManagementSystemAPI.Models.Dto.Response;
using EnrollmentManagementSystemAPI.Models.Entities;

namespace EnrollmentManagementSystemAPI.Services.Interfaces
{
    public interface ITermService
    {
        Task<IEnumerable<TermResponseDto>> GetAllTermsAsync();
        Task<TermResponseDto?> GetTermByIdAsync(int id);
        Task<TermResponseDto> CreateTermAsync(CreateTermDto createTermDto);
        Task<TermResponseDto> UpdateTermAsync(int id, CreateTermDto updateTermDto);
        Task<bool> DeleteTermAsync(int id);
    }
}
