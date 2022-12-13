using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NZWalksapi.Models.Domain;
using NZWalksapi.Repositories;
using System.Reflection.Metadata.Ecma335;

namespace NZWalksapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WalksController : Controller
    {
        private readonly IWalkReposetory walkReposetory;
        private readonly IMapper mapper;

        public WalksController(IWalkReposetory walkReposetory, IMapper mapper)
        {
            this.walkReposetory = walkReposetory;
            this.mapper = mapper;
        }

        
        [HttpGet]
        public async Task<IActionResult> GetAllWalksAsync()
        {
            var walks = await walkReposetory.GetAllAsync();
            var walksDTO = mapper.Map<List<Models.DTO.Walk>>(walks);
    
            return Ok(walks);
        }
        [HttpGet]
        [Route("{id:guid}")]
         public async Task<IActionResult>GetWalkAsync (Guid id)
        {
            var walkDomain = await walkReposetory.GetAsync(id);
            var walkDTO = mapper.Map<Models.DTO.Walk>(walkDomain);
            return Ok(walkDTO);
        }
    }
}