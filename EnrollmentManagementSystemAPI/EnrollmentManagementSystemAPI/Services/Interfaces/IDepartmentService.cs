using EnrollmentManagementSystemAPI.Models.Dto.Request;
using EnrollmentManagementSystemAPI.Models.Dto.Response;
using EnrollmentManagementSystemAPI.Models.Entities;

namespace EnrollmentManagementSystemAPI.Services.Interfaces
{
    public interface IDepartmentService
    {
        Task<IEnumerable<DepartmentReponseDto>> GetAllDepartmentsAsync();
        Task<DepartmentReponseDto?> GetDepartmentByIdAsync(int id);
        Task<DepartmentReponseDto> CreateDepartmentAsync(CreateDepartmentDto createDepartmentDto);
        Task<DepartmentReponseDto> UpdateDepartmentAsync(int id, CreateDepartmentDto updateDepartmentDto);
        Task<bool> DeleteDepartmentAsync(int id);
    }
}
