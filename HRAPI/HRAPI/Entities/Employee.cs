using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRAPI.Entities
{
    public class Employee
    {
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string FirstName { get; set; } = string.Empty;

        [Required, MaxLength(50)]
        public string LastName { get; set; } = string.Empty;

        [Required, EmailAddress, MaxLength(255)]
        public string Email { get; set; } = string.Empty;

        [Required, MaxLength(100)]
        public string JobTitle { get; set; } = string.Empty;

        [Column(TypeName = "decimal(18,2)")]
        [Range(0, double.MaxValue, ErrorMessage = "Salary must be non-negative.")]
        public decimal Salary { get; set; }

        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        public Department Department { get; set; } = null!;
    }
}
