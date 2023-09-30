using MediatR;
using NZWalks.API.Models.DTO.Walks.Requests;
using NZWalks.API.Models.Shared;

namespace NZWalks.API.Queries.Walks
{
    public class GetAllWalksQuery : IRequest<IEnumerable<WalkDto>>
    {
        public Filter Filter { get; }

        public GetAllWalksQuery(Filter filter)
        {
            Filter = filter;
        }
    }
}
