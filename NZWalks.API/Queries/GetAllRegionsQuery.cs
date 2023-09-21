using MediatR;
using NZWalks.API.Models.DTO.Regions.Requests;

namespace NZWalks.API.Queries
{
    public class GetAllRegionsQuery : IRequest<IEnumerable<RegionDto>>
    {

    }
}
