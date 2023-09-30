using AutoMapper;
using MediatR;
using NZWalks.API.Models.DTO.Walks.Requests;
using NZWalks.API.Queries.Walks;
using NZWalks.API.Repositories.Shared;

namespace NZWalks.API.QueryHandlers.Walks
{
    public class GetAllWalksQueryHandler : IRequestHandler<GetAllWalksQuery, IEnumerable<WalkDto>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetAllWalksQueryHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<WalkDto>> Handle(GetAllWalksQuery request, CancellationToken cancellationToken)
        {
            var Walks = await unitOfWork.Walk.GetAllAsync(request.Filter);

            return mapper.Map<IEnumerable<WalkDto>>(Walks);
        }
    }
}
