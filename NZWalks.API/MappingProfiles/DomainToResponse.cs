using AutoMapper;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO.Regions.Response;

namespace NZWalks.API.MappingProfiles
{
    public class DomainToResponse : Profile
    {
        public DomainToResponse()
        {
            CreateMap<Walk, WalkResponse>();
            CreateMap<Region, RegionResponse>();
        }
    }
}
