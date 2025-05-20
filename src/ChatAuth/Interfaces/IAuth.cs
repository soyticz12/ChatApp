using Microsoft.AspNetCore.Identity.Data;

namespace ChatAuth.Interfaces
{
    public interface IAuth 
    {
        Task<string> GetAccessTokenAsync();
        Task<string> GetRefreshTokenAsync();
        Task<bool> IsAuthenticatedAsync();
        Task<bool> IsExpiredAsync();
        Task<bool> SignInAsync(LoginRequest loginRequest);
        Task<bool> SignUpAsync(RegisterRequest registerRequest);
        Task<bool> SignOutAsync();
    }
}