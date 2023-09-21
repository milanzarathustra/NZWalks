using NZWalks.API.Enums.Global;

namespace NZWalks.API.Models.Domain
{
    public class BaseEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime AddedDate { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedDate { get; set; } = DateTime.UtcNow;
        public int Status { get; set; } = (int)StatusEnum.Live;
    }
}
