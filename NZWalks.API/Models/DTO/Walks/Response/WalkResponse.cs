using NZWalks.API.Models.DTO.Difficulties;
using NZWalks.API.Models.DTO.Regions.Requests;

namespace NZWalks.API.Models.DTO.Regions.Response
{
    public class WalkResponse
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public double LengthInKm { get; set; }
        public string? WalkImageUrl { get; set; }

        public RegionDto Region { get; set; } = new();
        public DifficultyDto Difficulty { get; set; } = new();
    }
}
