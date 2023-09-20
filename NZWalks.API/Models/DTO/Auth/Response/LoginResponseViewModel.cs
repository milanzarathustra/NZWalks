using NZWalks.API.Models.DTO.Shared;

namespace NZWalks.API.Models.DTO.Auth.Response
{
    public class LoginResponseViewModel : ViewModel
    {
        public string AuthenticationToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
