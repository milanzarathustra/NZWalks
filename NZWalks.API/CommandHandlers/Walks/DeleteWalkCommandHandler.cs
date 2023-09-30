using MediatR;
using NZWalks.API.Commands.Walks;
using NZWalks.API.Repositories.Shared;

namespace NZWalks.API.CommandHandlers.Walks
{
    public class DeleteWalkCommandHandler : IRequestHandler<DeleteWalkInfoRequest, bool>
    {
        private readonly IUnitOfWork unitOfWork;

        public DeleteWalkCommandHandler(
            IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteWalkInfoRequest request, CancellationToken cancellationToken)
        {
            var isDeleted = await unitOfWork.Walk.DeleteAsync(request.Id);

            if (!isDeleted)
                return false;

            await unitOfWork.CompleteAsync();

            return true;
        }
    }
}
