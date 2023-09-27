using AutoMapper;
using MediatR;
using NZWalks.API.Commands.Walks;
using NZWalks.API.Models.Domain;
using NZWalks.API.Repositories.Shared;

namespace NZWalks.API.CommandHandlers.Walks
{
    public class UpdateWalkCommandHandler : IRequestHandler<UpdateWalkInfoRequest, bool>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public UpdateWalkCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<bool> Handle(UpdateWalkInfoRequest request, CancellationToken cancellationToken)
        {
            var walk = mapper.Map<Walk>(request.WalkRequest);

            await unitOfWork.Walk.UpdateAsync(request.Id, walk);
            await unitOfWork.CompleteAsync();

            return true;
        }
    }
}
