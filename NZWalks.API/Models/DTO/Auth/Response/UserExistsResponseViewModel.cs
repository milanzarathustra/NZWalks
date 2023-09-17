namespace NZWalks.API.Models.DTO.Auth.Response
{
    public class UserExistsResponseViewModel
    {
        public string Username { get; set; }

        public bool Exists { get; set; }
    }
}
