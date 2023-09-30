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

        public override async Task<IEnumerable<Region>?> GetAllAsync(Filter filter)
        {
            var regions = context.Regions.Where(o => o.Status != (int)StatusEnum.Deleted).AsQueryable();

            //Filtering
            if (!string.IsNullOrWhiteSpace(filter.FilterOn) && !string.IsNullOrWhiteSpace(filter.FilterQuery))
            {
                if (filter.FilterOn.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    regions = regions.Where(x => x.Name.Contains(filter.FilterQuery));
                }
            }

            //Sorting
            if (!string.IsNullOrWhiteSpace(filter.SortBy))
            {
                if (filter.SortBy.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    regions = filter.IsAscending ? regions.OrderBy(x => x.Name) : regions.OrderByDescending(x => x.Name);
                }
            }

            //Pagination
            var skipPages = (filter.PageNumber - 1) * filter.PageSize;

            return await regions.Skip(skipPages).Take(filter.PageSize).ToListAsync();
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
