using App.DAL.Data;
using App.Domain.Entities;
using App.Domain.Interfaces.IRepositories;
using App.Domain.Interfaces.IServices;
using App.Domain.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Net.Mail;
using System.Security.Claims;
using System.Text;
using App.Application.OptionsSetup;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;

namespace App.Application.Services
{
    public class UserService : BaseService<User, int>, IUserService
    {
        private readonly IUserRepo _userRepo;
        private readonly JwtSettings _jwtSettings;

        public UserService(IOptions<JwtSettings> jwtSettings, DataContext dataContext, IMapper mapper, IUserRepo userRepo) :
            base(dataContext, mapper, userRepo)
        {
            _userRepo = userRepo;
            _jwtSettings = jwtSettings.Value;
        }

        public async Task<List<User>> GetAllUserAsync()
        {
            var user = await _dataContext.Users.ToListAsync();
            return user;
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            var user = await _dataContext.Users.FirstOrDefaultAsync(o => o.UserId == id);
            return user!;
        }

        public async Task<TokenModel> LoginAsync(LoginModel model)
        {
            var user = await _dataContext.Users.FirstOrDefaultAsync(o => o.UserName == model.UserName);
            if (user == null)
            {
                return null!;
            }

            if (model.Password != user!.Password)
            {
                return null!;
            }

            var token = new TokenModel
            {
                Token = GenerateJwtToken(user.UserName!, user.Role!)
            };
            return token;
        }

        private string GenerateJwtToken(string userName, string role)
        {
            try
            {
                var claims = new List<Claim>
                {
                    new("userName", Convert.ToString(userName)),
                    new("role", Convert.ToString(role)),
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey!));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var expires = DateTime.UtcNow.AddMinutes(60);

                var token = new JwtSecurityToken(
                    issuer: _jwtSettings.Issuer,
                    audience: _jwtSettings.Audience,
                    claims: claims,
                    expires: expires,
                    signingCredentials: creds
                );

                var tokenHandler = new JwtSecurityTokenHandler();
                return tokenHandler.WriteToken(token);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error generating JWT token: {ex.Message}");
                return null!;
            }
        }

        public async Task<int> RegisterAsync(LoginModel model)
        {
            var user = await _dataContext.Users.FirstOrDefaultAsync(o => o.UserName == model.UserName);
            if (user != null)
            {
                return 1;
            }

            var newUser = new User()
            {
                UserName = model.UserName,
                Password = model.Password,
                Role = "User"
            };

            _dbSet.Add(newUser);
            await _dataContext.SaveChangesAsync();
            return 0;
        }
        public async Task<int> SendPasswordResetOTP(string email)
        {

            var user = _dataContext.Users.FirstOrDefault(o => o.Email == email);
            if (user == null)
            {
                return 1;
            }
            var otp = new Random().Next(100000, 999999).ToString();
            var otpExpiry = DateTime.Now.AddMinutes(5);

            var sendOtp = SendOtpToEmailAsync(user.Email!, "Your password reset OTP", $"Your OTP is: {otp}");
            if (sendOtp != 0)
            {
                return 2;
            }
            user.Otp = otp;
            user.OtpExpiry = otpExpiry;
            await _userRepo.UpdateAsync(user);
            return 0;
        }
        public int SendOtpToEmailAsync(string toEmail, string subject, string body)
        {
            var fromAddress = new MailAddress("thanhnc279@gmail.com", "ThanhNC");
            var toAddress = new MailAddress(toEmail, "To Name");
            const string fromPassword = "yfagiawekhvcuism";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };

            using var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            };
            smtp.Send(message);
            return 0;
        }

        public async Task<int> ResetPasswordAsync(SentOtpModel model)
        {
            var user = await _dataContext.Users.FirstOrDefaultAsync(o => o.UserName == model.UserName);
            if (user == null)
            {
                return 1;
            }
            if (user.Otp != model.Otp || DateTime.UtcNow > user.OtpExpiry)
            {
                return 2;
            }
            user.Otp = null;
            user.OtpExpiry = null;
            user.Password = model.NewPassword;
            await _dataContext.SaveChangesAsync();
            return 0;
        }
    }
}