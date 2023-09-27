using MediatR;
using NZWalks.API.Models.DTO.Walks.Requests;

namespace NZWalks.API.Queries.Walks
{
    public class GetWalkQuery : IRequest<WalkDto>
    {
        public Guid Id { get; }

        public GetWalkQuery(Guid id)
        {
            Id = id;
        }
    }
}
