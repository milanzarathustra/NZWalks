namespace NZWalks.API.Models.DTO.Auth.Response
{
    public class JwtAuthResponseViewModel
    {
        public string AccessToken { get; set; }
        public RefreshTokenResponseViewModel RefreshToken { get; set; }
    }
}
