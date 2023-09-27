using MediatR;
using NZWalks.API.Commands.Regions;
using NZWalks.API.Repositories.Shared;

namespace NZWalks.API.CommandHandlers.Regions
{
    public class DeleteRegionCommandHandler : IRequestHandler<DeleteRegionInfoRequest, bool>
    {
        private readonly IUnitOfWork unitOfWork;

        public DeleteRegionCommandHandler(
            IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteRegionInfoRequest request, CancellationToken cancellationToken)
        {
            var isDeleted = await unitOfWork.Region.DeleteAsync(request.Id);

            if (!isDeleted)
                return false;

            await unitOfWork.CompleteAsync();

            return true;
        }
    }
}
