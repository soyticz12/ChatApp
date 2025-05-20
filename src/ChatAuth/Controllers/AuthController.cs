using ChatAuth.Interfaces;
using ChatAuth.Models;
using ChatAuth.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Supabase;
namespace ChatAuth.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController(AuthService authService) : ControllerBase
{
    private readonly AuthService _authService = authService;

    [HttpGet("token")]
    public async Task<IActionResult> GetAccessToken()
    {
        var token = await _authService.GetAccessTokenAsync();
        return Ok(token);
    }
    [HttpPost("signin")]
    public async Task<IActionResult> SignIn(LoginRequest loginRequest)
    {
        var result = await _authService.SignInAsync(loginRequest);
        if (result)
        {
            return Ok("Sign in successful");
        }
        return Unauthorized("Invalid credentials");
    }
    [HttpPost("signup")]
    public async Task<IActionResult> SignUp(RegisterRequest registerRequest)
    {
        var result = await _authService.SignUpAsync(registerRequest);
        if (result)
        {
            return Ok("Sign up successful");
        }
        return BadRequest("Sign up failed");
    }
    [HttpPost("signout")]
    public async Task<IActionResult> SignOut()
    {
        var result = await _authService.SignOutAsync();
        if (result)
        {
            return Ok("Sign out successful");
        }
        return BadRequest("Sign out failed");
    }
}