namespace App.Domain.Models;

public class SentOtpModel
{
    public string UserName { get; set; }
    public string Otp { get; set; }
    public string NewPassword { get; set; }    
}