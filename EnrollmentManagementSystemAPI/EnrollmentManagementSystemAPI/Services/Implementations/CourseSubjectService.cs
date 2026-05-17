using AutoMapper;
using EnrollmentManagementSystemAPI.data;
using EnrollmentManagementSystemAPI.Models.Dto.Request;
using EnrollmentManagementSystemAPI.Models.Dto.Response;
using EnrollmentManagementSystemAPI.Models.Entities;
using EnrollmentManagementSystemAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EnrollmentManagementSystemAPI.Services.Implementations
{
    public class CourseSubjectService : ICourseSubjectService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CourseSubjectService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CourseSubjectResponseDto>> GetAllCourseSubjectsAsync()
        {
            var courseSubjects = await _context.CourseSubjects.ToListAsync();
            return _mapper.Map<IEnumerable<CourseSubjectResponseDto>>(courseSubjects);
        }

        public async Task<CourseSubjectResponseDto?> GetCourseSubjectByIdAsync(int id)
        {
            var courseSubject = await _context.CourseSubjects.FindAsync(id);
            return courseSubject == null ? null : _mapper.Map<CourseSubjectResponseDto>(courseSubject);
        }

        public async Task<CourseSubjectResponseDto> CreateCourseSubjectAsync(CreateCourseSubjectDto createCourseSubjectDto)
        {
            var courseSubject = _mapper.Map<CourseSubject>(createCourseSubjectDto);
            _context.CourseSubjects.Add(courseSubject);
            await _context.SaveChangesAsync();
            return _mapper.Map<CourseSubjectResponseDto>(courseSubject);
        }

        public async Task<CourseSubjectResponseDto> UpdateCourseSubjectAsync(int id, CreateCourseSubjectDto updateCourseSubjectDto)
        {
            var courseSubject = await _context.CourseSubjects.FindAsync(id);
            if (courseSubject == null)
            {
                throw new KeyNotFoundException($"CourseSubject with ID {id} not found.");
            }

            _mapper.Map(updateCourseSubjectDto, courseSubject);
            _context.CourseSubjects.Update(courseSubject);
            await _context.SaveChangesAsync();
            return _mapper.Map<CourseSubjectResponseDto>(courseSubject);
        }

        public async Task<bool> DeleteCourseSubjectAsync(int id)
        {
            var courseSubject = await _context.CourseSubjects.FindAsync(id);
            if (courseSubject == null)
            {
                throw new KeyNotFoundException($"CourseSubject with ID {id} not found.");
            }

            _context.CourseSubjects.Remove(courseSubject);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
