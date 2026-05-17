using AutoMapper;
using EnrollmentManagementSystemAPI.data;
using EnrollmentManagementSystemAPI.Models.Dto.Request;
using EnrollmentManagementSystemAPI.Models.Dto.Response;
using EnrollmentManagementSystemAPI.Models.Entities;
using EnrollmentManagementSystemAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EnrollmentManagementSystemAPI.Services.Implementations
{
    public class SubjectService : ISubjectService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public SubjectService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SubjectResponseDto>> GetAllSubjectsAsync()
        {
            var subjects = await _context.Subjects.ToListAsync();
            return _mapper.Map<IEnumerable<SubjectResponseDto>>(subjects);
        }

        public async Task<SubjectResponseDto?> GetSubjectByIdAsync(int id)
        {
            var subject = await _context.Subjects.FindAsync(id);
            return subject == null ? null : _mapper.Map<SubjectResponseDto>(subject);
        }

        public async Task<SubjectResponseDto> CreateSubjectAsync(CreateSubjectDto createSubjectDto)
        {
            var subject = _mapper.Map<Subject>(createSubjectDto);
            _context.Subjects.Add(subject);
            await _context.SaveChangesAsync();
            return _mapper.Map<SubjectResponseDto>(subject);
        }

        public async Task<SubjectResponseDto> UpdateSubjectAsync(int id, CreateSubjectDto updateSubjectDto)
        {
            var subject = await _context.Subjects.FindAsync(id);
            if (subject == null)
            {
                throw new KeyNotFoundException($"Subject with ID {id} not found.");
            }

            _mapper.Map(updateSubjectDto, subject);
            _context.Subjects.Update(subject);
            await _context.SaveChangesAsync();
            return _mapper.Map<SubjectResponseDto>(subject);
        }

        public async Task<bool> DeleteSubjectAsync(int id)
        {
            var subject = await _context.Subjects.FindAsync(id);
            if (subject == null)
            {
                throw new KeyNotFoundException($"Subject with ID {id} not found.");
            }

            _context.Subjects.Remove(subject);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
