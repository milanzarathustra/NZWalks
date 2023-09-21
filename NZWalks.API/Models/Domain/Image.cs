using System.ComponentModel.DataAnnotations.Schema;

namespace NZWalks.API.Models.Domain
{
    public class Image : BaseEntity
    {
        [NotMapped]
        public IFormFile? File { get; set; }

        public string FileName { get; set; } = string.Empty;

        public string? FileDescription { get; set; } = string.Empty;

        public string FileExtension { get; set; } = string.Empty;

        public long FileSizeInBytes { get; set; }

        public string FilePath { get; set; } = string.Empty;
    }
}
