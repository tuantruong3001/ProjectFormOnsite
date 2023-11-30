using System.ComponentModel.DataAnnotations;

namespace App.Domain.Models
{
    public class ConfirmModel
    {
        public int Status { get; set; }
        public string Detail { get; set; } = string.Empty;
        public string Reason { get; set; } = string.Empty;
    }
}
