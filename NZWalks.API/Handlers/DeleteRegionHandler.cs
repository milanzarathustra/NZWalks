using MediatR;
using NZWalks.API.Commands;
using NZWalks.API.Repositories.Shared;

namespace NZWalks.API.Handlers
{
    public class DeleteRegionHandler : IRequestHandler<DeleteRegionInfoRequest, bool>
    {
        private readonly IUnitOfWork unitOfWork;

        public DeleteRegionHandler(
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
