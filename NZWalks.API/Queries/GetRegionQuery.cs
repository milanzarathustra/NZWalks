﻿using MediatR;
using NZWalks.API.Models.DTO.Regions.Requests;

namespace NZWalks.API.Queries
{
    public class GetRegionQuery : IRequest<RegionDto>
    {
        public Guid Id { get; }

        public GetRegionQuery(Guid id)
        {
            Id = id;
        }
    }
}
