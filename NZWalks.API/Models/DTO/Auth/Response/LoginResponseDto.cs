namespace NZWalks.API.Models.DTO.Auth.Response
{
    public class LoginResponseDto
    {
        public string AuthenticationToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
