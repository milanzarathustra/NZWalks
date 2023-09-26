using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Commands;
using NZWalks.API.Middlewares.CustomActionFilters;
using NZWalks.API.Models.DTO.Regions.Requests;
using NZWalks.API.Models.Shared;
using NZWalks.API.Queries;
using NZWalks.API.Repositories.Shared;

namespace NZWalks.API.Controllers
{
    //http://localhost:1234/api/regions
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : BaseController
    {
        public RegionsController(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IMediator mediator) : base(unitOfWork, mapper, mediator)
        {
        }

        [HttpGet]
        //[Authorize(Roles = "Reader, Writer")] //Either one of these roles
        public async Task<IActionResult> GetAll(
            [FromQuery] Filter filter)
        {
            var query = new GetAllRegionsQuery(filter);

            var result = await mediator.Send(query);

            return Ok(result);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        //[Authorize(Roles = "Reader")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var query = new GetRegionQuery(id);

            var result = await mediator.Send(query);

            return Ok(result);
        }

        [HttpPost]
        [ValidateModel]
        //[Authorize(Roles = "Writer")]
        public async Task<IActionResult> Create([FromBody] CreateRegionRequest createRegionRequest) 
        {
            var command = new CreateRegionInfoRequest(createRegionRequest);

            var result = await mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]
        //[Authorize(Roles = "Writer")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRegionRequest updateRegionRequest)
        {
            var command = new UpdateRegionInfoRequest(id, updateRegionRequest);

            var result = await mediator.Send(command);

            return result ? NoContent() : BadRequest();
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        //[Authorize(Roles = "Writer")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var command = new DeleteRegionInfoRequest(id);

            var result = await mediator.Send(command);

            return result ? NoContent() : BadRequest();
        }
    }
}
