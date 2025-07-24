using System.ComponentModel.DataAnnotations;

namespace HRAPI.Entities
{
    public class UserDto
    {
        [Required, MaxLength(50)]
        public string Username { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;

        [Required, MaxLength(20)]
        public string Role { get; set; } = string.Empty;

        [Required]
        public int EmployeeId { get; set; } // Must be assigned during registration
    }
}
