using AutoMapper;
using MediatR;
using NZWalks.API.Models.DTO.Walks.Requests;
using NZWalks.API.Queries.Walks;
using NZWalks.API.Repositories.Shared;

namespace NZWalks.API.QueryHandlers.Walks
{
    public class GetWalkQueryHandler : IRequestHandler<GetWalkQuery, WalkDto>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetWalkQueryHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<WalkDto> Handle(GetWalkQuery request, CancellationToken cancellationToken)
        {
            var Walk = await unitOfWork.Walk.GetByIdAsync(request.Id);

            return Walk == null ? new WalkDto { } : mapper.Map<WalkDto>(Walk);
        }
    }
}
