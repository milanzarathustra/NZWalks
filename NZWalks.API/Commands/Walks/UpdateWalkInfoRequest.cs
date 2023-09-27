using MediatR;
using NZWalks.API.Models.DTO.Walks.Requests;

namespace NZWalks.API.Commands.Walks
{
    public class UpdateWalkInfoRequest : IRequest<bool>
    {
        public Guid Id { get; }
        public UpdateWalkRequest WalkRequest { get; }

        public UpdateWalkInfoRequest(Guid id, UpdateWalkRequest walkRequest)
        {
            Id = id;
            WalkRequest = walkRequest;
        }
    }
}
