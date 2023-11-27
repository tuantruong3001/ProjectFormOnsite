using ProjectFormOnsite.Data;

namespace ProjectFormOnsite.Models
{
    public class EmployeeModel
    {
        public int EmployeeID { get; set; }
        public int DepartmentID { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public virtual Department? Department { get; set; }
    }
}
