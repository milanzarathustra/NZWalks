using System.ComponentModel.DataAnnotations;

namespace NZWalks.API.Models.DTO.Upload
{
    public class ImageUploadRequest
    {
        [Required]
        public IFormFile? File { get; set; }

        [Required]
        public string FileName { get; set; } = string.Empty;

        public string? FileDescription { get; set; }
    }
}
