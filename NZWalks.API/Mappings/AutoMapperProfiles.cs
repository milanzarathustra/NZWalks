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
            CreateMap<AddRegionRequestDto, Region>().ReverseMap();
            CreateMap<UpdateRegionRequestDto, Region>().ReverseMap();

            //Walks
            CreateMap<Walk, WalkDto>().ReverseMap();
            CreateMap<AddWalkRequestDto, Walk>().ReverseMap();
            CreateMap<UpdateWalkRequestDto, Walk>().ReverseMap();

            //Difficulty
            CreateMap<Difficulty, DifficultyDto>().ReverseMap();
        }
    }
}
