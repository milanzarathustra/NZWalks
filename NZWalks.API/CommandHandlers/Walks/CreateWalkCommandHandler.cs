using AutoMapper;
using MediatR;
using NZWalks.API.Commands.Walks;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO.Walks.Requests;
using NZWalks.API.Repositories.Shared;

namespace NZWalks.API.CommandHandlers.Walks
{
    public class CreateWalkCommandHandler : IRequestHandler<CreateWalkInfoRequest, WalkDto>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public CreateWalkCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<WalkDto> Handle(CreateWalkInfoRequest request, CancellationToken cancellationToken)
        {
            var Walk = mapper.Map<Walk>(request.WalkRequest);

            await unitOfWork.Walk.CreateAsync(Walk);
            await unitOfWork.CompleteAsync();

            return mapper.Map<WalkDto>(Walk);
        }
    }
}
