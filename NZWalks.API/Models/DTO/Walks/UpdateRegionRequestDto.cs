using System.ComponentModel.DataAnnotations;

namespace NZWalks.API.Models.DTO.Walks
{
    public class UpdateWalkRequestDto
    {
        [Required]
        [MaxLength(100, ErrorMessage = "Name can only be a maximum of 100 characters")]
        public string Name { get; set; }

        [Required]
        [MaxLength(255, ErrorMessage = "Name can only be a maximum of 255 characters")]
        public string Description { get; set; }

        [Required]
        public double LengthInKm { get; set; }

        public string? WalkImageUrl { get; set; }

        [Required]
        public Guid DifficultyId { get; set; }

        [Required]
        public Guid RegionId { get; set; }
    }
}
