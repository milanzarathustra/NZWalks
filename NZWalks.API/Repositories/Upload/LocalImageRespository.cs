using NZWalks.API.Data;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories.Upload
{
    public class LocalImageRespository : IImageRepository
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly NZWalksDbContext dbContext;

        public LocalImageRespository(IWebHostEnvironment webHostEnvironment, 
            IHttpContextAccessor httpContextAccessor,
            NZWalksDbContext dbContext)
        {
            this.webHostEnvironment = webHostEnvironment;
            this.httpContextAccessor = httpContextAccessor;
            this.dbContext = dbContext;
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

                await dbContext.Images.AddAsync(image);
                await dbContext.SaveChangesAsync();
            }

            return image;
        }
    }
}
