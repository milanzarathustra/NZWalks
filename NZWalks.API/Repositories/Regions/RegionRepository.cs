using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Enums.Global;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.Shared;
using NZWalks.API.Repositories.Shared;

namespace NZWalks.API.Repositories.Regions
{
    public class RegionRepository : GenericRepository<Region>, IRegionRepository
    {
        public RegionRepository(NZWalksDbContext context, ILogger logger) : base(context, logger)
        {
        }

        public override async Task<IEnumerable<Region>?> GetAllAsync(Query? query)
        {
            return await context.Regions.ToListAsync();
        }

        public override async Task<Region?> GetByIdAsync(Guid id)
        {
            return await context.Regions.FindAsync(id);
        }

        public override async Task<bool> UpdateAsync(Guid id, Region region)
        {
            var existingRegion = await GetByIdAsync(id);

            if (existingRegion == null) 
                return false;

            existingRegion.Code = region.Code;
            existingRegion.Name = region.Name;
            existingRegion.RegionImageUrl = region.RegionImageUrl;

            existingRegion.UpdatedDate = DateTime.UtcNow;

            return true;
        }

        public override async Task<bool> DeleteAsync(Guid id, bool shadowDelete = true)
        {
            var existingRegion = await GetByIdAsync(id);

            if (existingRegion == null)
                return false;

            if (shadowDelete)
            {
                existingRegion.Status = (int)StatusEnum.Deleted;
                existingRegion.UpdatedDate = DateTime.UtcNow;
            }
            else
            {
                context.Regions.Remove(existingRegion);
            }

            return true;
        }
    }
}
