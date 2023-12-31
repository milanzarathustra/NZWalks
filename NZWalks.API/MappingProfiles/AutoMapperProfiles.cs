﻿using AutoMapper;
using NZWalks.API.Enums.Global;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO.Difficulties;
using NZWalks.API.Models.DTO.Regions.Requests;
using NZWalks.API.Models.DTO.Walks.Requests;

namespace NZWalks.API.MappingProfiles
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            //Regions
            CreateMap<Region, RegionDto>().ReverseMap();
            CreateMap<CreateRegionRequest, Region>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => StatusEnum.Live))
                .ForMember(dest => dest.AddedDate, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.UpdatedDate, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ReverseMap();
            CreateMap<UpdateRegionRequest, Region>()
                .ForMember(dest => dest.UpdatedDate, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ReverseMap();

            //Walks
            CreateMap<Walk, WalkDto>().ReverseMap();
            CreateMap<CreateWalkRequest, Walk>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => 1))
                .ForMember(dest => dest.AddedDate, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.UpdatedDate, opt => opt.MapFrom(src => DateTime.UtcNow));

            CreateMap<UpdateWalkRequest, Walk>()
                .ForMember(dest => dest.UpdatedDate, opt => opt.MapFrom(src => DateTime.UtcNow));

            //Difficulty
            CreateMap<Difficulty, DifficultyDto>().ReverseMap();
        }
    }
}
