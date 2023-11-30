using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace App.Domain.Entities
{
    [Table("Onsite")]
    public class Onsite
    {
        [Key]
        public int OnsiteID { get; set; }
        public int EmployeeID { get; set; }
        public int ApproverID { get; set; }
        public string Destination { get; set; } = string.Empty;
        public string StartDate { get; set; } = string.Empty;
        public string EndDate { get; set; } = string.Empty;
        public int Status { get; set; }
        public string Detail { get; set; } = string.Empty;
        public string Reason { get; set; } = string.Empty;
        public virtual Employee? Employee { get; set; }
        public virtual Employee? Approver { get; set; }
    }
}
