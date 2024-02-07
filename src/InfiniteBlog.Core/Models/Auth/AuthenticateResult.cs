namespace InfiniteBlog.Core.Models.Auth
{
    public class AuthenticateResult
    {
        public required string Token { get; set; }

        public required string RefreshToken { get; set; }
    }
}
