using NZWalks.API.Models.DTO.Difficulties;
using NZWalks.API.Models.DTO.Regions;

namespace NZWalks.API.Models.DTO.Walks
{
    public class WalkDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double LengthInKm { get; set; }
        public string? WalkImageUrl { get; set; }

        public RegionDto Region { get; set; }
        public DifficultyDto Difficulty { get; set; }
    }
}
