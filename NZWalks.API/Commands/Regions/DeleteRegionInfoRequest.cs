using MediatR;

namespace NZRegions.API.Commands.Regions
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
