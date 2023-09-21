using NZWalks.API.Models.Domain;
using NZWalks.API.Repositories.Shared;

namespace NZWalks.API.Repositories.Upload
{
    public interface IImageRepository : IGenericRepository<Region>
    {
        Task<Image> Upload(Image image);
    }
}
