using App.Domain.Entities;
using App.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Interfaces.IServices
{
    public interface IUserService : IBaseService<User, int>
    {
        Task<List<User>> GetAllUserAsync();
        Task<User> GetUserByIdAsync(int ids);
        Task<int> RegisterAsync(LoginModel model);
        Task<TokenModel> LoginAsync(LoginModel model);
        int SendOtpToEmailAsync(string toEmail, string subject, string body);
        Task<int> SendPasswordResetOTP(string email);
        Task<int> ResetPasswordAsync(SentOtpModel model);
    }
}
