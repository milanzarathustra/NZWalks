namespace NZWalks.API.Models.DTO.Auth.Response
{
    public class JwtAuthResponseViewModel
    {
        public string AccessToken { get; set; } = string.Empty;
        public RefreshTokenResponseViewModel? RefreshToken { get; set; }
    }
}
