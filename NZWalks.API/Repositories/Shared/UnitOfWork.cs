using NZWalks.API.Data;
using NZWalks.API.Repositories.Regions;
using NZWalks.API.Repositories.Walks;

namespace NZWalks.API.Repositories.Shared
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly NZWalksDbContext context;

        public IRegionRepository Region { get; }
        public IWalkRepository Walk { get; }

        public UnitOfWork(
            NZWalksDbContext context, 
            ILoggerFactory loggerFactory)
        {
            this.context = context;

            var logger = loggerFactory.CreateLogger("logs");

            Region = new RegionRepository(context, logger);
            Walk = new WalkRepository(context, logger);
        }

        public async Task<bool> CompleteAsync()
        {
            var result = await context.SaveChangesAsync();

            return result > 0;
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
