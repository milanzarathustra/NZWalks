using MediatR;
using NZWalks.API.Models.DTO.Regions.Requests;

namespace NZWalks.API.Commands.Regions
{
    public class UpdateRegionInfoRequest : IRequest<bool>
    {
        public Guid Id { get; }
        public UpdateRegionRequest RegionRequest { get; }

        public UpdateRegionInfoRequest(Guid id, UpdateRegionRequest regionRequest)
        {
            Id = id;
            RegionRequest = regionRequest;
        }

    }
}
