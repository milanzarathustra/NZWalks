namespace NZWalks.API.Models.DTO.Auth
{
    public class UserExistsResponseDto
    {
        public string Username { get; set; }

        public bool Exists { get; set; }
    }
}
