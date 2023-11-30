namespace App.Domain.Models
{
    public class RegisterOnsiteModel
    {
        public int EmployeeID { get; set; }
        public string Destination { get; set; } = string.Empty;
        public string StartDate { get; set; } = string.Empty;
        public string EndDate { get; set; } = string.Empty;
        public int Status { get; set; }
        public string Detail { get; set; } = string.Empty;
        public string Reason { get; set; } = string.Empty;
    }
}
