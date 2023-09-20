using System.ComponentModel.DataAnnotations;

namespace NZWalks.API.Models.DTO.Auth.Request
{
    public class RefreshRequest
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string RefreshToken { get; set; }
    }
}
