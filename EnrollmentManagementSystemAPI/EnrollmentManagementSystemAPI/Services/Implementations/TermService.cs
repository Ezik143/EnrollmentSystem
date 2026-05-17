using AutoMapper;
using EnrollmentManagementSystemAPI.data;
using EnrollmentManagementSystemAPI.Models.Dto.Request;
using EnrollmentManagementSystemAPI.Models.Dto.Response;
using EnrollmentManagementSystemAPI.Models.Entities;
using EnrollmentManagementSystemAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EnrollmentManagementSystemAPI.Services.Implementations
{
    public class TermService : ITermService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public TermService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TermResponseDto>> GetAllTermsAsync()
        {
            var terms = await _context.Term.ToListAsync();
            return _mapper.Map<IEnumerable<TermResponseDto>>(terms);
        }

        public async Task<TermResponseDto?> GetTermByIdAsync(int id)
        {
            var term = await _context.Term.FindAsync(id);
            return term == null ? null : _mapper.Map<TermResponseDto>(term);
        }

        public async Task<TermResponseDto> CreateTermAsync(CreateTermDto createTermDto)
        {
            var term = _mapper.Map<Term>(createTermDto);
            _context.Term.Add(term);
            await _context.SaveChangesAsync();
            return _mapper.Map<TermResponseDto>(term);
        }

        public async Task<TermResponseDto> UpdateTermAsync(int id, CreateTermDto updateTermDto)
        {
            var term = await _context.Term.FindAsync(id);
            if (term == null)
            {
                throw new KeyNotFoundException($"Term with ID {id} not found.");
            }

            _mapper.Map(updateTermDto, term);
            _context.Term.Update(term);
            await _context.SaveChangesAsync();
            return _mapper.Map<TermResponseDto>(term);
        }

        public async Task<bool> DeleteTermAsync(int id)
        {
            var term = await _context.Term.FindAsync(id);
            if (term == null)
            {
                throw new KeyNotFoundException($"Term with ID {id} not found.");
            }

            _context.Term.Remove(term);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
