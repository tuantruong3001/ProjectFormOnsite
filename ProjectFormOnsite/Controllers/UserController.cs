using App.Domain.Interfaces.IServices;
using App.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IServiceProvider iConfigurationProvider)
    {
        _userService = iConfigurationProvider.GetRequiredService<IUserService>();
    }

    [HttpGet]
    public async Task<IActionResult> GetAllUser()
    {
        var user = await _userService.GetAllUserAsync();
        return Ok(user);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserById(int id)
    {
        var user = await _userService.GetUserByIdAsync(id);
        return user == null ? NotFound() : Ok(user);
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login(LoginModel model)
    {
        var user = await _userService.LoginAsync(model);
        if(user == null)
        {
            return BadRequest("UserName or Password is wrong!");
        }
        return Ok(user);
    }

    [HttpPost("Register")]
    public async Task<IActionResult> Register(LoginModel model)
    {
        var user = await _userService.RegisterAsync(model);
        if (user == 1)
        {
            return BadRequest("UserName is exist!");
        }

        return Ok();
    }

    [HttpPost("SendOtpToEmail")]
    public async Task<IActionResult> RequestPasswordReset(string email)
    {
        var user = await _userService.SendPasswordResetOTP(email);
        if(user == 1)
        {
            return BadRequest("Email was wrong!");
        }
        if(user == 2)
        {
            return BadRequest("Cant send OTP!");
        }
        return Ok("Otp has been sent successfully to your email!");
    }

    [HttpPost("ResetPassword")]
    public async Task<IActionResult> ResetPassword(SentOtpModel model)
    {
        var user = await _userService.ResetPasswordAsync(model);
        if (user == 1)
        {
            return BadRequest("UserName isn't exist!");
        }
            
        if (user == 2)
        {
            return BadRequest("OTP is invalid!");
        }

        return Ok("Password has been change successfully.");
    }
        
}