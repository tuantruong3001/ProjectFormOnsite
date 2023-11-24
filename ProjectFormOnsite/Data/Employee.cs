using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectFormOnsite.Data
{
    [Table("Employee")]
    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }
        [ForeignKey("DepartmentID")]
        public int  DepartmentID { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
<<<<<<< HEAD
        public virtual Department? Department { get; set; }
=======
        /*public virtual ICollection<Onsite>? OnsitesAsEmployee { get; set; }
        public virtual ICollection<Onsite>? OnsitesAsApprover { get; set; }
        public virtual Department? Department { get; set; }*/
>>>>>>> d044544857ee7f92a98cede580844aeaa1d15e28
    }
}
