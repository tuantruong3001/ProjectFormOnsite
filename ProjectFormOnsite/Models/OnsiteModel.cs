
using System.ComponentModel.DataAnnotations;

namespace App.API.Models
{
    public class OnsiteModel
    {
        public int OnsiteID { get; set; }
        [Required]
        public int EmployeeID { get; set; }
        [Required]
        public int ApproverID { get; set; }
        public string Destination { get; set; } = string.Empty;
        public string StartDate { get; set; } = string.Empty;
        public string EndDate { get; set; } = string.Empty;
        public int Status { get; set; }
        public string Detail { get; set; } = string.Empty;
        public string Reason { get; set; } = string.Empty;      

    }
}
