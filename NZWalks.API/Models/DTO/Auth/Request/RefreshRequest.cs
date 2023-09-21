using System.ComponentModel.DataAnnotations;

namespace NZWalks.API.Models.DTO.Auth.Request
{
    public class RefreshRequest
    {
        [Required]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string RefreshToken { get; set; } = string.Empty;
    }
}
