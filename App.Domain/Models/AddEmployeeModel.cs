using System.ComponentModel.DataAnnotations;

namespace App.Domain.Models
{
    public class AddEmployeeModel
    {
        public int EmployeeID { get; set; }
        [Required]
        public int DepartmentID { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
    }
}
