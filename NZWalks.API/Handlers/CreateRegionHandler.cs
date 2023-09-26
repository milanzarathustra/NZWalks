using AutoMapper;
using MediatR;
using NZWalks.API.Commands;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO.Regions.Requests;
using NZWalks.API.Repositories.Shared;

namespace NZWalks.API.Handlers
{
    public class CreateRegionHandler : IRequestHandler<CreateRegionInfoRequest, RegionDto>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public CreateRegionHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<RegionDto> Handle(CreateRegionInfoRequest request, CancellationToken cancellationToken)
        {
            var region = mapper.Map<Region>(request.RegionRequest);

            await unitOfWork.Region.CreateAsync(region);
            await unitOfWork.CompleteAsync();

            return mapper.Map<RegionDto>(region);
        }
    }
}
