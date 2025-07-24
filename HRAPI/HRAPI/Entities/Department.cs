using System;
using System.ComponentModel.DataAnnotations;

namespace HRAPI.Entities
{
    public class Department
    {
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        public List<Employee> Employees { get; set; } = new();
    }
}
