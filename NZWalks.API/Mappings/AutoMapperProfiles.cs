using AutoMapper;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO.Difficulties;
using NZWalks.API.Models.DTO.Regions;
using NZWalks.API.Models.DTO.Walks;

namespace NZWalks.API.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            //Regions
            CreateMap<Region, RegionDto>().ReverseMap();
            CreateMap<AddRegionRequest, Region>().ReverseMap();
            CreateMap<UpdateRegionRequest, Region>().ReverseMap();

            //Walks
            CreateMap<Walk, WalkDto>().ReverseMap();
            CreateMap<AddWalkRequest, Walk>().ReverseMap();
            CreateMap<UpdateWalkRequest, Walk>().ReverseMap();

            //Difficulty
            CreateMap<Difficulty, DifficultyDto>().ReverseMap();
        }
    }
}
