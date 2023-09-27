using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Enums.Global;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.Shared;
using NZWalks.API.Repositories.Shared;

namespace NZWalks.API.Repositories.Walks
{
    public class WalkRepository : GenericRepository<Walk>, IWalkRepository 
    {
        public WalkRepository(NZWalksDbContext context, ILogger logger) : base(context, logger)
        {
        }

        public override async Task<IEnumerable<Walk>?> GetAllAsync(Filter filter)
        {
            var walks = context.Walks.Include(x => x.Difficulty).Include(x => x.Region).Where(o => o.Status != (int)StatusEnum.Deleted).AsQueryable();

            //Filtering
            if (!string.IsNullOrWhiteSpace(filter.FilterOn) && !string.IsNullOrWhiteSpace(filter.FilterQuery))
            {
                if (filter.FilterOn.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    walks = walks.Where(x => x.Name.Contains(filter.FilterQuery));
                }
            }

            //Sorting
            if (!string.IsNullOrWhiteSpace(filter.SortBy))
            {
                if (filter.SortBy.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    walks = filter.IsAscending ? walks.OrderBy(x => x.Name) : walks.OrderByDescending(x => x.Name);
                }
                else if (filter.SortBy.Equals("Length", StringComparison.OrdinalIgnoreCase))
                {
                    walks = filter.IsAscending ? walks.OrderBy(x => x.LengthInKm) : walks.OrderByDescending(x => x.LengthInKm);
                }
            }

            //Pagination
            var skipPages = (filter.PageNumber - 1) * filter.PageSize;

            return await walks.Skip(skipPages).Take(filter.PageSize).ToListAsync();
        }

        public override async Task<Walk?> GetByIdAsync(Guid id)
        {
            return await context.Walks.Include(x => x.Difficulty).Include(x => x.Region).FirstOrDefaultAsync(x => x.Id == id);
        }

        public override async Task<bool> UpdateAsync(Guid id, Walk walk)
        {
            var existingWalk = await GetByIdAsync(id);

            if (existingWalk == null)
                return false;

            existingWalk.Name = walk.Name;
            existingWalk.Description = walk.Description;
            existingWalk.LengthInKm = walk.LengthInKm;
            existingWalk.WalkImageUrl = walk.WalkImageUrl;
            existingWalk.DifficultyId = walk.DifficultyId;
            existingWalk.RegionId = walk.RegionId;

            existingWalk.UpdatedDate = DateTime.UtcNow;

            return true;
        }

        public override async Task<bool> DeleteAsync(Guid id, bool shadowDelete = true)
        {
            var existingWalk = await GetByIdAsync(id);

            if (existingWalk == null) 
                return false;

            if (shadowDelete)
            {
                existingWalk.Status = (int)StatusEnum.Deleted;
                existingWalk.UpdatedDate = DateTime.UtcNow;
            }
            else
            {
                context.Walks.Remove(existingWalk);
            }

            return true;
        }
    }
}
