using NZWalks.API.Repositories.Regions;
using NZWalks.API.Repositories.Walks;

namespace NZWalks.API.Repositories.Shared
{
    public interface IUnitOfWork
    {
        IRegionRepository Region { get; }
        IWalkRepository Walk { get; }

        Task<bool> CompleteAsync();
    }
}
