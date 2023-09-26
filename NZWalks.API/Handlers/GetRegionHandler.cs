using AutoMapper;
using MediatR;
using NZWalks.API.Models.DTO.Regions.Requests;
using NZWalks.API.Queries;
using NZWalks.API.Repositories.Shared;

namespace NZWalks.API.Handlers
{
    public class GetRegionHandler : IRequestHandler<GetRegionQuery, RegionDto>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetRegionHandler(
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
