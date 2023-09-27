using MediatR;
using NZWalks.API.Models.DTO.Walks.Requests;

namespace NZWalks.API.Commands.Walks
{
    public class CreateWalkInfoRequest : IRequest<WalkDto>
    {
        public CreateWalkRequest WalkRequest { get; }

        public CreateWalkInfoRequest(CreateWalkRequest walkRequest)
        {
            WalkRequest = walkRequest;
        }
    }
}
