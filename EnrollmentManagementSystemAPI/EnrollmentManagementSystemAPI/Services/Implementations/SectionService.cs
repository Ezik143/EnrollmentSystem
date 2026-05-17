using AutoMapper;
using EnrollmentManagementSystemAPI.data;
using EnrollmentManagementSystemAPI.Models.Dto.Request;
using EnrollmentManagementSystemAPI.Models.Dto.Response;
using EnrollmentManagementSystemAPI.Models.Entities;
using EnrollmentManagementSystemAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EnrollmentManagementSystemAPI.Services.Implementations
{
    public class SectionService : ISectionService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public SectionService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SectionResponseDto>> GetAllSectionsAsync()
        {
            var sections = await _context.Sections.ToListAsync();
            return _mapper.Map<IEnumerable<SectionResponseDto>>(sections);
        }

        public async Task<SectionResponseDto?> GetSectionByIdAsync(int id)
        {
            var section = await _context.Sections.FindAsync(id);
            return section == null ? null : _mapper.Map<SectionResponseDto>(section);
        }

        public async Task<SectionResponseDto> CreateSectionAsync(CreateSectionDto createSectionDto)
        {
            var section = _mapper.Map<Section>(createSectionDto);
            _context.Sections.Add(section);
            await _context.SaveChangesAsync();
            return _mapper.Map<SectionResponseDto>(section);
        }

        public async Task<SectionResponseDto> UpdateSectionAsync(int id, CreateSectionDto updateSectionDto)
        {
            var section = await _context.Sections.FindAsync(id);
            if (section == null)
            {
                throw new KeyNotFoundException($"Section with ID {id} not found.");
            }

            _mapper.Map(updateSectionDto, section);
            _context.Sections.Update(section);
            await _context.SaveChangesAsync();
            return _mapper.Map<SectionResponseDto>(section);
        }

        public async Task<bool> DeleteSectionAsync(int id)
        {
            var section = await _context.Sections.FindAsync(id);
            if (section == null)
            {
                throw new KeyNotFoundException($"Section with ID {id} not found.");
            }

            _context.Sections.Remove(section);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
