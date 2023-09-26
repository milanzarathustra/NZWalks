using MediatR;
using NZWalks.API.Models.DTO.Regions.Requests;

namespace NZWalks.API.Commands
{
    public class DeleteRegionInfoRequest : IRequest<bool>
    {
        public Guid Id { get; }

        public DeleteRegionInfoRequest(Guid id)
        {
            Id = id;
        }

    }
}
