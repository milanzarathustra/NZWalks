using Microsoft.EntityFrameworkCore;
using NZWalks.API.Enums.Global;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Data
{
    public class NZWalksDbContext: DbContext
    {
        public NZWalksDbContext(DbContextOptions<NZWalksDbContext> dbContextOptions) : base(dbContextOptions)
        {                  
        }

        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }
        public DbSet<Image> Images { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Seed data for difficulties
            //Easy, Medium, Hard

            var difficulties = new List<Difficulty>() 
            { 
                new Difficulty()
                {
                    Id = Guid.Parse("82ff4bef-e4d8-4784-a45d-e09038b6b95d"),
                    Name = "Easy",
                    Status = (int)StatusEnum.Live,
                    AddedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow,
                },
                new Difficulty()
                {
                    Id = Guid.Parse("0be7662a-6cf8-45ca-aa0e-9088d9b41ece"),
                    Name = "Medium",
                    Status = (int)StatusEnum.Live,
                    AddedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow,
                },
                new Difficulty()
                {
                    Id = Guid.Parse("cc765ba3-3470-471f-915d-100fe14fdef0"),
                    Name = "Hard",
                    Status = (int)StatusEnum.Live,
                    AddedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow,
                }
            };

            //Seed difficulties to the database
            modelBuilder.Entity<Difficulty>().HasData(difficulties);

            //Seed data for regions
            var region = new List<Region>()
            {
                new Region()
                {
                    Id = Guid.Parse("b082d575-2826-4277-91f5-d300ddcf3438"),
                    Name = "AuckLand",
                    Code = "AKL",
                    RegionImageUrl = "https://test.com/image1.png",
                    Status = (int)StatusEnum.Live,
                    AddedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow
                },
                new Region()
                {
                    Id = Guid.Parse("a4f8ab81-6c1a-4935-b996-d77d822ac369"),
                    Name = "NorthLand",
                    Code = "NTL",
                    RegionImageUrl = "https://test.com/image2.png",
                    Status = (int)StatusEnum.Live,
                    AddedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow
                },
                new Region()
                {
                    Id = Guid.Parse("84a43188-0df0-4337-a9fa-e7851cddff14"),
                    Name = "Bay of Plenty",
                    Code = "BOP",
                    RegionImageUrl = "https://test.com/image3.png",
                    Status = (int)StatusEnum.Live,
                    AddedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow
                },
                new Region()
                {
                    Id = Guid.Parse("51440791-8a91-4e61-8f6d-602860252f93"),
                    Name = "Wellington",
                    Code = "WGN",
                    RegionImageUrl = "https://test.com/image4.png",
                    Status = (int)StatusEnum.Live,
                    AddedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow
                },
                new Region()
                {
                    Id = Guid.Parse("390b81b6-0879-481a-8720-42f5b8637c41"),
                    Name = "Nelson",
                    Code = "NSN",
                    RegionImageUrl = "https://test.com/image5.png",
                    Status = (int)StatusEnum.Live,
                    AddedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow
                },
            };

            modelBuilder.Entity<Region>().HasData(region);
        }
    }
}
