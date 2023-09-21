using NZWalks.API.Data;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.Shared;

namespace NZWalks.API.Repositories.Upload
{
    public class ImageRepository : IImageRepository
    {
        private readonly NZWalksDbContext context;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IHttpContextAccessor httpContextAccessor;

        public ImageRepository(
            IWebHostEnvironment webHostEnvironment, 
            IHttpContextAccessor httpContextAccessor,
            NZWalksDbContext context)
        {
            this.context = context;
            this.webHostEnvironment = webHostEnvironment;
            this.httpContextAccessor = httpContextAccessor;
        }

        public Task<bool> CreateAsync(Region entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(Guid id, bool shadowDelete = true)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Region>?> GetAllAsync(Filter? query)
        {
            throw new NotImplementedException();
        }

        public Task<Region?> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Guid id, Region entity)
        {
            throw new NotImplementedException();
        }

        public async Task<Image> Upload(Image image)
        {
            var localFilePath = 
                Path.Combine(
                    webHostEnvironment.ContentRootPath, 
                    "Assets", 
                    image.FileName + 
                    image.FileExtension);

            using (var stream = new FileStream(localFilePath, FileMode.Create))
            {
                await image.File.CopyToAsync(stream);

                var httpContextRequest = httpContextAccessor.HttpContext.Request;

                var filePathUrl = $"{httpContextRequest.Scheme}://{httpContextRequest.Host}{httpContextRequest.PathBase}/Assets/{image.FileName}{image.FileExtension}";

                image.FilePath = filePathUrl;

                await context.Images.AddAsync(image);
                await context.SaveChangesAsync();
            }

            return image;
        }
    }
}
