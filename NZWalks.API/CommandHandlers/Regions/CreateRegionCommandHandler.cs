using AutoMapper;
using MediatR;
using NZWalks.API.Commands.Regions;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO.Regions.Requests;
using NZWalks.API.Repositories.Shared;

namespace NZRegions.API.CommandHandlers.Regions
{
    public class CreateRegionCommandHandler : IRequestHandler<CreateRegionInfoRequest, RegionDto>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public CreateRegionCommandHandler(
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
