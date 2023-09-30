using AutoMapper;
using MediatR;
using NZWalks.API.Models.DTO.Regions.Requests;
using NZWalks.API.Queries.Regions;
using NZWalks.API.Repositories.Shared;

namespace NZWalks.API.QueryHandlers.Regions
{
    public class GetRegionQueryHandler : IRequestHandler<GetRegionQuery, RegionDto>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetRegionQueryHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<RegionDto> Handle(GetRegionQuery request, CancellationToken cancellationToken)
        {
            var region = await unitOfWork.Region.GetByIdAsync(request.Id);

            return region == null ? new RegionDto { } : mapper.Map<RegionDto>(region);
        }
    }
}
