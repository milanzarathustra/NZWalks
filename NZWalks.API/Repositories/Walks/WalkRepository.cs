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

        public override async Task<IEnumerable<Walk>?> GetAllAsync(Query? query)
        {
            var walks = context.Walks.Include(x => x.Difficulty).Include(x => x.Region).AsQueryable();

            //Filtering
            if (!string.IsNullOrWhiteSpace(query.FilterOn) && !string.IsNullOrWhiteSpace(query.FilterQuery))
            {
                if (query.FilterOn.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    walks = walks.Where(x => x.Name.Contains(query.FilterQuery));
                }
            }

            //Sorting
            if (!string.IsNullOrWhiteSpace(query.SortBy))
            {
                if (query.SortBy.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    walks = query.IsAscending ? walks.OrderBy(x => x.Name) : walks.OrderByDescending(x => x.Name);
                }
                else if (query.SortBy.Equals("Length", StringComparison.OrdinalIgnoreCase))
                {
                    walks = query.IsAscending ? walks.OrderBy(x => x.LengthInKm) : walks.OrderByDescending(x => x.LengthInKm);
                }
            }

            //Pagination
            var skipPages = (query.PageNumber - 1) * query.PageSize;

            return await walks.Skip(skipPages).Take(query.PageSize).ToListAsync();
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
