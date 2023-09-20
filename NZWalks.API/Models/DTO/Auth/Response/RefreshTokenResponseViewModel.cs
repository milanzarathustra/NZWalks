namespace NZWalks.API.Models.DTO.Auth.Response
{
    public class RefreshTokenResponseViewModel
    {
        public string UserName { get; set; }
        public string TokenString { get; set; }
        public DateTime ExpireAt { get; set; }
    }
}
