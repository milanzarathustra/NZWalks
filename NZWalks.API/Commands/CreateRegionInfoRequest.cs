﻿using MediatR;
using NZWalks.API.Models.DTO.Regions.Requests;

namespace NZWalks.API.Commands
{
    public class CreateRegionInfoRequest : IRequest<RegionDto>
    {
        public CreateRegionRequest RegionRequest { get; }

        public CreateRegionInfoRequest(CreateRegionRequest regionRequest)
        {
            RegionRequest = regionRequest;
        }

    }
}
