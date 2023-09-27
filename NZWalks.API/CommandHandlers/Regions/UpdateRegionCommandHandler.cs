using AutoMapper;
using MediatR;
using NZWalks.API.Commands.Regions;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO.Regions.Requests;
using NZWalks.API.Repositories.Shared;

namespace NZWalks.API.CommandHandlers.Regions
{
    public class UpdateRegionCommandHandler : IRequestHandler<UpdateRegionInfoRequest, bool>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public UpdateRegionCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<bool> Handle(UpdateRegionInfoRequest request, CancellationToken cancellationToken)
        {
            var region = mapper.Map<Region>(request.RegionRequest);

            await unitOfWork.Region.UpdateAsync(request.Id, region);
            await unitOfWork.CompleteAsync();

            return true;
        }
    }
}
