using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories.Upload
{
    public interface IImageRepository
    {
        Task<Image> Upload(Image image);
    }
}
