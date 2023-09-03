using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.CustomActionFilters;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO.Walks;
using NZWalks.API.Repositories.Walks;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IWalkRepository walkRepository;
        private readonly IMapper mapper;

        public WalksController(IWalkRepository walkRepository, IMapper mapper)
        {
            this.walkRepository = walkRepository;
            this.mapper = mapper;
        }

        //GET ALL WALKS
        [HttpGet]
        public async Task<IActionResult> GetAll(
            [FromQuery] string? filterOn, 
            [FromQuery] string? filterQuery, 
            [FromQuery] string? sortBy, 
            [FromQuery] bool? IsAscending,
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 1000)
        {
            var walksDomain = await walkRepository.GetAllAsync(filterOn, filterQuery, sortBy, IsAscending ?? true, pageNumber, pageSize);

            return Ok(mapper.Map<List<WalkDto>>(walksDomain));
        }

        //GET SINGLE WALK BY ID
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var walkDomainModel = await walkRepository.GetByIdAsync(id);

            if (walkDomainModel == null) { return NotFound(); }

            return Ok(mapper.Map<WalkDto>(walkDomainModel));
        }

        //POST CREATE WALK
        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Create([FromBody] AddWalkRequestDto addWalkRequestDto)
        {
            var walkDomainModel = mapper.Map<Walk>(addWalkRequestDto);

            walkDomainModel = await walkRepository.CreateAsync(walkDomainModel);

            return CreatedAtAction(nameof(GetById), new { id = walkDomainModel.Id }, mapper.Map<WalkDto>(walkDomainModel));
        }

        //PUT UPDATE WALK
        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateWalkRequestDto updateWalkRequestDto)
        {
            var walkDomainModel = mapper.Map<Walk>(updateWalkRequestDto);

            walkDomainModel = await walkRepository.UpdateAsync(id, walkDomainModel);

            if (walkDomainModel == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<WalkDto>(walkDomainModel));
        }

        //DELETE A WALK
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var walkDomainModel = await walkRepository.DeleteAsync(id);

            if (walkDomainModel == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<WalkDto>(walkDomainModel));
        }
    }
}
