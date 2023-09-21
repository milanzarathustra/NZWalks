using System.ComponentModel.DataAnnotations;

namespace NZWalks.API.Models.DTO.Auth.Request
{
    public class RegisterRequest
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Username { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        public string[] Roles { get; set; } = new string[0];
    }
}
