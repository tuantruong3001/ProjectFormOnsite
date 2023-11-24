using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectFormOnsite.Data
{
    [Table("Department")]
    public class Department
    {
        [Key]
        public int DepartmentID { get; set; }
        public string? DepartmentName { get; set; }

    }
}
