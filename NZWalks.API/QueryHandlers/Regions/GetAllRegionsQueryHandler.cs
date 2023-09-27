using AutoMapper;
using MediatR;
using NZWalks.API.Models.DTO.Regions.Requests;
using NZWalks.API.Queries.Regions;
using NZWalks.API.Repositories.Shared;

namespace NZWalks.API.QueryHandlers.Regions
{
    public class GetAllRegionsQueryHandler : IRequestHandler<GetAllRegionsQuery, IEnumerable<RegionDto>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetAllRegionsQueryHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<RegionDto>> Handle(GetAllRegionsQuery request, CancellationToken cancellationToken)
        {
            var regions = await unitOfWork.Region.GetAllAsync(request.Filter);

            return mapper.Map<IEnumerable<RegionDto>>(regions);
        }
    }
}
