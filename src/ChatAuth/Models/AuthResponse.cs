namespace ChatAuth.Models
{
    public class AuthResponse
    {
        public bool Success { get; set; }
        public string? AccessToken { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? ExpiresAt { get; set; }  // Optional: token expiration time
        public string? UserId { get; set; }       // Supabase UID or user identifier
        public string? Email { get; set; }        // Optional: user's email
        public string? ErrorMessage { get; set; } // Filled if Success == false
    }
}
