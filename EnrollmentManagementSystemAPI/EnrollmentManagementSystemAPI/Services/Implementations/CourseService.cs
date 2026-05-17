using AutoMapper;
using EnrollmentManagementSystemAPI.data;
using EnrollmentManagementSystemAPI.Models.Dto.Request;
using EnrollmentManagementSystemAPI.Models.Dto.Response;
using EnrollmentManagementSystemAPI.Models.Entities;
using EnrollmentManagementSystemAPI.Services.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace EnrollmentManagementSystemAPI.Services.Implementations
{
    public class CourseService : ICourseService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateCourseDto> _validator;

        public CourseService(ApplicationDbContext context, IMapper mapper, IValidator<CreateCourseDto> validator)
        {
            _context = context;
            _mapper = mapper;
            _validator = validator;
        }
        public async Task<IEnumerable<CourseResponseDto>> GetAllCoursesAsync()
        {
            var courses = await _context.Courses.ToListAsync();
            return _mapper.Map<IEnumerable<CourseResponseDto>>(courses);
        }

        public async Task<CourseResponseDto?> GetCourseByIdAsync(int id)
        {
            var course = await _context.Courses.FindAsync(id);
            return course == null ? null : _mapper.Map<CourseResponseDto>(course);
        }

        public async Task<CourseResponseDto> CreateCourseAsync(CreateCourseDto createCourseDto)
        {
            var validationResult = await _validator.ValidateAsync(createCourseDto);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            var course = _mapper.Map<Course>(createCourseDto);
            _context.Courses.Add(course);
            await _context.SaveChangesAsync();
            return _mapper.Map<CourseResponseDto>(course);
        }

        public async Task<CourseResponseDto> UpdateCourseAsync(int id, CreateCourseDto updateCourseDto)
        {
            var validationResult = await _validator.ValidateAsync(updateCourseDto);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            var course = await _context.Courses.FindAsync(id);
            if (course == null)
            {
                throw new KeyNotFoundException($"Course with ID {id} not found.");
            }

            _mapper.Map(updateCourseDto, course);
            _context.Courses.Update(course);
            await _context.SaveChangesAsync();
            return _mapper.Map<CourseResponseDto>(course);
        }

        public async Task<bool> DeleteCourseAsync(int id)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course == null)
            {
                throw new KeyNotFoundException($"Course with ID {id} not found.");
            }

            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
