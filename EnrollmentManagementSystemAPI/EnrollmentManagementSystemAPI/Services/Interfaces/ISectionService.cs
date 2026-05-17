using EnrollmentManagementSystemAPI.Models.Dto.Request;
using EnrollmentManagementSystemAPI.Models.Dto.Response;
using EnrollmentManagementSystemAPI.Models.Entities;

namespace EnrollmentManagementSystemAPI.Services.Interfaces
{
    public interface ISectionService
    {
        Task<IEnumerable<SectionResponseDto>> GetAllSectionsAsync();
        Task<SectionResponseDto?> GetSectionByIdAsync(int id);
        Task<SectionResponseDto> CreateSectionAsync(CreateSectionDto createSectionDto);
        Task<SectionResponseDto> UpdateSectionAsync(int id, CreateSectionDto updateSectionDto);
        Task<bool> DeleteSectionAsync(int id);
    }
}
