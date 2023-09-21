namespace NZWalks.API.Models.Domain
{
    public class Walk : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public double LengthInKm { get; set; }
        public string? WalkImageUrl { get; set; }
        public Guid DifficultyId { get; set; }
        public Guid RegionId { get; set; }

        //Navigation Properties
        public Difficulty Difficulty { get; set; } = new();
        public Region Region { get; set; } = new();
    }
}
