using System.ComponentModel.DataAnnotations;

namespace NZWalks.API.Models.DTO.Auth.Request
{
    public class RefreshRequestDto
    {
        [Required]
        public string RefreshToken { get; set; }
    }
}
