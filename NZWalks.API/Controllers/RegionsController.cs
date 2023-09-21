using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Middlewares.CustomActionFilters;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO.Regions.Requests;
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
            IMapper mapper) : base (unitOfWork, mapper) 
        { 
        }

        [HttpGet]
        //[Authorize(Roles = "Reader, Writer")] //Either one of these roles
        public async Task<IActionResult> GetAll(
            [FromQuery] string? filterOn,
            [FromQuery] string? filterQuery,
            [FromQuery] string? sortBy,
            [FromQuery] bool? isAscending,
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 1000)
        {
            var result = await unitOfWork.Region.GetAllAsync(null);

            return Ok(result);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        //[Authorize(Roles = "Reader")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var result = await unitOfWork.Region.GetByIdAsync(id);

            if (result == null) 
                return NotFound();

            return Ok(result);
        }

        [HttpPost]
        [ValidateModel]
        //[Authorize(Roles = "Writer")]
        public async Task<IActionResult> Create([FromBody] CreateRegionRequest createRegionRequest) 
        {
            var result = mapper.Map<Region>(createRegionRequest);

            await unitOfWork.Region.CreateAsync(result);
            await unitOfWork.CompleteAsync();

            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]
        //[Authorize(Roles = "Writer")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRegionRequest updateRegionRequest)
        {
            var result = mapper.Map<Region>(updateRegionRequest);

            await unitOfWork.Region.UpdateAsync(id, result);
            await unitOfWork.CompleteAsync();

            return NoContent();
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        //[Authorize(Roles = "Writer")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            await unitOfWork.Region.DeleteAsync(id);
            await unitOfWork.CompleteAsync();

            return NoContent();
        }
    }
}
