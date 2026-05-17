using AutoMapper;
using EnrollmentManagementSystemAPI.data;
using EnrollmentManagementSystemAPI.Models.Dto.Request;
using EnrollmentManagementSystemAPI.Models.Dto.Response;
using EnrollmentManagementSystemAPI.Models.Entities;
using EnrollmentManagementSystemAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EnrollmentManagementSystemAPI.Services.Implementations
{
    public class DepartmentService : IDepartmentService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public DepartmentService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DepartmentReponseDto>> GetAllDepartmentsAsync()
        {
            var departments = await _context.Departments.ToListAsync();
            return _mapper.Map<IEnumerable<DepartmentReponseDto>>(departments);
        }

        public async Task<DepartmentReponseDto?> GetDepartmentByIdAsync(int id)
        {
            var department = await _context.Departments.FindAsync(id);
            return department == null ? null : _mapper.Map<DepartmentReponseDto>(department);
        }

        public async Task<DepartmentReponseDto> CreateDepartmentAsync(CreateDepartmentDto createDepartmentDto)
        {
            var department = _mapper.Map<Department>(createDepartmentDto);
            _context.Departments.Add(department);
            await _context.SaveChangesAsync();
            return _mapper.Map<DepartmentReponseDto>(department);
        }

        public async Task<DepartmentReponseDto> UpdateDepartmentAsync(int id, CreateDepartmentDto updateDepartmentDto)
        {
            var department = await _context.Departments.FindAsync(id);
            if (department == null)
            {
                throw new KeyNotFoundException($"Department with ID {id} not found.");
            }

            _mapper.Map(updateDepartmentDto, department);
            _context.Departments.Update(department);
            await _context.SaveChangesAsync();
            return _mapper.Map<DepartmentReponseDto>(department);
        }

        public async Task<bool> DeleteDepartmentAsync(int id)
        {
            var department = await _context.Departments.FindAsync(id);
            if (department == null)
            {
                throw new KeyNotFoundException($"Department with ID {id} not found.");
            }

            _context.Departments.Remove(department);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
