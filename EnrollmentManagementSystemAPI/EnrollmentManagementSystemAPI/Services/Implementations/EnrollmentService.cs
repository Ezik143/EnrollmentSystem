using AutoMapper;
using EnrollmentManagementSystemAPI.data;
using EnrollmentManagementSystemAPI.Models.Dto.Request;
using EnrollmentManagementSystemAPI.Models.Dto.Response;
using EnrollmentManagementSystemAPI.Models.Entities;
using EnrollmentManagementSystemAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EnrollmentManagementSystemAPI.Services.Implementations
{
    public class EnrollmentService : IEnrollmentService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public EnrollmentService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IEnumerable<EnrollmentResponseDto>> GetAllEnrollmentsAsync()
        {
            var enrollments = await _context.Enrollments.ToListAsync();
            return _mapper.Map<IEnumerable<EnrollmentResponseDto>>(enrollments);
        }

        public async Task<EnrollmentResponseDto?> GetEnrollmentByIdAsync(int id)
        {
            var enrollment = await _context.Enrollments.FindAsync(id);
            return enrollment == null ? null : _mapper.Map<EnrollmentResponseDto>(enrollment);
        }

        public async Task<EnrollmentResponseDto> CreateEnrollmentAsync(CreateEnrollmentDto createEnrollmentDto)
        {
            var enrollment = _mapper.Map<Enrollment>(createEnrollmentDto);
            _context.Enrollments.Add(enrollment);
            await _context.SaveChangesAsync();
            return _mapper.Map<EnrollmentResponseDto>(enrollment);
        }

        public async Task<EnrollmentResponseDto> UpdateEnrollmentAsync(int id, CreateEnrollmentDto updateEnrollmentDto)
        {
            var enrollment = await _context.Enrollments.FindAsync(id);
            if (enrollment == null)
            {
                throw new KeyNotFoundException($"Enrollment with ID {id} not found.");
            }

            _mapper.Map(updateEnrollmentDto, enrollment);
            _context.Enrollments.Update(enrollment);
            await _context.SaveChangesAsync();
            return _mapper.Map<EnrollmentResponseDto>(enrollment);
        }

        public async Task<bool> DeleteEnrollmentAsync(int id)
        {
            var enrollment = await _context.Enrollments.FindAsync(id);
            if (enrollment == null)
            {
                throw new KeyNotFoundException($"Enrollment with ID {id} not found.");
            }

            _context.Enrollments.Remove(enrollment);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
