using AutoMapper;
using EnrollmentManagementSystemAPI.data;
using EnrollmentManagementSystemAPI.Models.Dto.Request;
using EnrollmentManagementSystemAPI.Models.Dto.Response;
using EnrollmentManagementSystemAPI.Models.Entities;
using EnrollmentManagementSystemAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EnrollmentManagementSystemAPI.Services.Implementations
{
    public class InstructorService : IInstructorService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public InstructorService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<InstructorResponseDto>> GetAllInstructorsAsync()
        {
            var instructors = await _context.Instructors.ToListAsync();
            return _mapper.Map<IEnumerable<InstructorResponseDto>>(instructors);
        }

        public async Task<InstructorResponseDto?> GetInstructorByIdAsync(int id)
        {
            var instructor = await _context.Instructors.FindAsync(id);
            return instructor == null ? null : _mapper.Map<InstructorResponseDto>(instructor);
        }

        public async Task<InstructorResponseDto> CreateInstructorAsync(CreateInstructorDto createInstructorDto)
        {
            var instructor = _mapper.Map<Instructor>(createInstructorDto);
            _context.Instructors.Add(instructor);
            await _context.SaveChangesAsync();
            return _mapper.Map<InstructorResponseDto>(instructor);
        }

        public async Task<InstructorResponseDto> UpdateInstructorAsync(int id, CreateInstructorDto updateInstructorDto)
        {
            var instructor = await _context.Instructors.FindAsync(id);
            if (instructor == null)
            {
                throw new KeyNotFoundException($"Instructor with ID {id} not found.");
            }

            _mapper.Map(updateInstructorDto, instructor);
            _context.Instructors.Update(instructor);
            await _context.SaveChangesAsync();
            return _mapper.Map<InstructorResponseDto>(instructor);
        }

        public async Task<bool> DeleteInstructorAsync(int id)
        {
            var instructor = await _context.Instructors.FindAsync(id);
            if (instructor == null)
            {
                throw new KeyNotFoundException($"Instructor with ID {id} not found.");
            }

            _context.Instructors.Remove(instructor);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
