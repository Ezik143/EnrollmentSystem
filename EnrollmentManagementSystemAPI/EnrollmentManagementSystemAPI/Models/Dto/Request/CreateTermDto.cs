using System.ComponentModel.DataAnnotations;

namespace EnrollmentManagementSystemAPI.Models.Dto.Request
{
    public class CreateTermDto
    {
        [Required, Range(1, int.MaxValue)]
        public int TermCode { get; set; }
        [Required, StringLength(100)]
        public string Name { get; set; } = string.Empty;
        [Required, DataType(DataType.Date)]
        public DateOnly StartDate { get; set; }
        [Required, DataType(DataType.Date)]
        public DateOnly EndDate { get; set; }
        [Required]
        public bool IsCurrent { get; set; }
    }
}
