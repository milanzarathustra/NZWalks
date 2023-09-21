namespace NZWalks.API.Models.DTO.Auth.Response
{
    public class UserExistsResponseViewModel
    {
        public string Username { get; set; } = string.Empty;

        public bool Exists { get; set; }
    }
}
