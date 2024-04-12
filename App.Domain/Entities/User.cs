using System.ComponentModel.DataAnnotations;

namespace App.Domain.Entities
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? Role { get; set; }
        public string? Otp { get; set; }
        public DateTime? OtpExpiry  { get; set; }
        public string? Email  { get; set; }
    }
}
