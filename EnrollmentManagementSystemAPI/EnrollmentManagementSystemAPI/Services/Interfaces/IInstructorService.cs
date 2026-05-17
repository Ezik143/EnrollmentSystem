using EnrollmentManagementSystemAPI.Models.Dto.Request;
using EnrollmentManagementSystemAPI.Models.Dto.Response;
using EnrollmentManagementSystemAPI.Models.Entities;

namespace EnrollmentManagementSystemAPI.Services.Interfaces
{
    public interface IInstructorService
    {
        Task<IEnumerable<InstructorResponseDto>> GetAllInstructorsAsync();
        Task<InstructorResponseDto?> GetInstructorByIdAsync(int id);
        Task<InstructorResponseDto> CreateInstructorAsync(CreateInstructorDto createInstructorDto);
        Task<InstructorResponseDto> UpdateInstructorAsync(int id, CreateInstructorDto updateInstructorDto);
        Task<bool> DeleteInstructorAsync(int id);
    }
}
