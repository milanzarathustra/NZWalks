using MediatR;
using NZWalks.API.Models.DTO.Regions.Requests;
using NZWalks.API.Models.Shared;

namespace NZWalks.API.Queries.Regions
{
    public class GetAllRegionsQuery : IRequest<IEnumerable<RegionDto>>
    {
        public Filter Filter { get; }

        public GetAllRegionsQuery(Filter filter)
        {
            Filter = filter;
        }
    }
}
