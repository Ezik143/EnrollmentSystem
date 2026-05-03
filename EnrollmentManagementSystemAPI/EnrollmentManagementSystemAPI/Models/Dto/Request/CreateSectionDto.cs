using EnrollmentManagementSystemAPI.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace EnrollmentManagementSystemAPI.Models.Dto.Request
{
    public class CreateSectionDto
    {
        [Required]
        public int InstructorId { get; set; }
        [Required]
        public int CourseId {   get; set; }
        [Required]
        public int CourseSubjectId { get; set; }
        [Required]
        public int TermId { get; set; }
        [Required, Range(1, 10)]
        public int Capacity { get; set; }
        [Required, Range(1, 10)]
        public string Name { get; set; }
    }
}
