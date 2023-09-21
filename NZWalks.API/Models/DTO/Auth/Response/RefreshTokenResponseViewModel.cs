namespace NZWalks.API.Models.DTO.Auth.Response
{
    public class RefreshTokenResponseViewModel
    {
        public string UserName { get; set; } = string.Empty;
        public string TokenString { get; set; } = string.Empty;
        public DateTime ExpireAt { get; set; }
    }
}
