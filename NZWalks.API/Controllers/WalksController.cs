using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Middlewares.CustomActionFilters;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO.Walks.Requests;
using NZWalks.API.Repositories.Shared;
using NZWalks.API.Repositories.Walks;
using System.Security.AccessControl;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : BaseController
    {
        public WalksController(
            IUnitOfWork unitOfWork,
            IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        //GET ALL WALKS
        [HttpGet]
        public async Task<IActionResult> GetAll(
            [FromQuery] string? filterOn, 
            [FromQuery] string? filterQuery, 
            [FromQuery] string? sortBy, 
            [FromQuery] bool? isAscending,
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 1000)
        {
            var result = await unitOfWork.Walk.GetAllAsync(null);

            //throw new Exception("This is a custom exception");

            return Ok(result);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var result = await unitOfWork.Walk.GetByIdAsync(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Create([FromBody] CreateWalkRequest addWalkRequest)
        {
            var result = mapper.Map<Walk>(addWalkRequest);

            await unitOfWork.Walk.CreateAsync(result);
            await unitOfWork.CompleteAsync();

            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateWalkRequest updateWalkRequest)
        {
            var result = mapper.Map<Walk>(updateWalkRequest);

            await unitOfWork.Walk.UpdateAsync(id, result);
            await unitOfWork.CompleteAsync();

            return NoContent();
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            await unitOfWork.Walk.DeleteAsync(id);
            await unitOfWork.CompleteAsync();

            return NoContent();
        }
    }
}
