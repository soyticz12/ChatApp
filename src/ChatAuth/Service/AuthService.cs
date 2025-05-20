using ChatAuth.Interfaces;
using Supabase;
using ChatAuth.Models;
using Microsoft.AspNetCore.Identity.Data;
namespace ChatAuth.Service;
public class AuthService(Client client) : IAuth
{
    private readonly Client _client = client;

    public Task<string> GetAccessTokenAsync()
    {
        var session = _client.Auth.CurrentSession;
        return Task.FromResult(session?.AccessToken ?? string.Empty);
    }

    public Task<string> GetRefreshTokenAsync()
    {
        var session = _client.Auth.CurrentSession;
        return Task.FromResult(session?.RefreshToken ?? string.Empty);
    }

    public Task<bool> IsAuthenticatedAsync()
    {
        var session = _client.Auth.CurrentSession;
        return Task.FromResult(session != null && !string.IsNullOrEmpty(session.AccessToken));
    }

    public Task<bool> IsExpiredAsync()
    {
        var session = _client.Auth.CurrentSession;
        if (session == null || session.ExpiresAt == null)
            return Task.FromResult(true);

        var expiry = session.ExpiresAt();
        return Task.FromResult(DateTime.UtcNow >= expiry);
    }

    public Task<bool> SignInAsync(LoginRequest loginRequest)
    {
        var result = _client.Auth.SignInWithPassword(loginRequest.Email, loginRequest.Password);
        return Task.FromResult(result != null);
    }

    public Task<bool> SignOutAsync()
    {
        var result = _client.Auth.SignOut();
        return Task.FromResult(result != null);
    }

    public Task<bool> SignUpAsync(RegisterRequest registerRequest)
    {
        var result = _client.Auth.SignUp(registerRequest.Email, registerRequest.Password);
        return Task.FromResult(result != null);
    }

}