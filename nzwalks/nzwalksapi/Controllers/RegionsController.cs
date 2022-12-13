using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NZWalksapi.Models.Domain;
using NZWalksapi.Repositories;
using System.Reflection.Metadata.Ecma335;

namespace NZWalksapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegionsController : Controller
    {
        private readonly IRegionReposetory regionReposetory;
        private readonly IMapper mapper;

        public RegionsController(IRegionReposetory regionReposetory, IMapper mapper)
        {
            this.regionReposetory = regionReposetory;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> getAllRegionsAsync()
        {

            var regions = await regionReposetory.GetAllAsync();
            /*var regionsDTO = new List<Models.DTO.Region>();
            regions.ToList().ForEach(region =>
            {
                var regionDTO = new Models.DTO.Region()
                {
                    Id = region.Id,
                    Name = region.Name,
                    Code = region.Code,
                    Area = region.Area,
                    Lat = region.Lat,
                    Long = region.Long,
                    Population = region.Population,

                };
                regionsDTO.Add(regionDTO);
            });*/
            var regionsDTO = mapper.Map<List<Models.DTO.Region>>(regions);

            return Ok(regionsDTO);
        }

        #region get regions
        [HttpGet]
        [Route("{id:Guid}")]
        [ActionName("GetRegionAsync")]

        public async Task<IActionResult> GetRegionAsync(Guid id)
        {
            var region = await regionReposetory.GetAsync(id);
            if (region == null)
            {
                return NotFound();
            }
            var regionDTO = mapper.Map<Models.DTO.Region>(region);
            return Ok(regionDTO);
        }
        #endregion


        [HttpPost]

        public async Task<IActionResult> addRegionAsync(Models.DTO.AddRegionRequest addRegionRequest)
        {
            var region = new Models.Domain.Region()
            {
                Code = addRegionRequest.Code,
                Area = addRegionRequest.Area,
                Lat = addRegionRequest.Lat,
                Long = addRegionRequest.Long,
                Name = addRegionRequest.Name,
                Population = addRegionRequest.Population

            };
            region = await regionReposetory.AddAsync(region);

            var regionDTO = new Models.DTO.Region
            {
                Id = region.Id,
                Code = region.Code,
                Area = region.Area,
                Lat = region.Lat,
                Long = region.Long,
                Name = region.Name,
                Population = region.Population

            };
            return CreatedAtAction(nameof(GetRegionAsync), new { id = regionDTO.Id }, regionDTO);
        }


        [HttpDelete]
        [Route("{id:guid}")]

        public async Task<IActionResult> deleteRegionAsync(Guid id)
        {
            var region = await regionReposetory.DeleteAsync(id);
            if (region == null)
            {
                return NotFound();
            }
            var regionDTO = new Models.DTO.Region
            {
                Code = region.Code,
                Area = region.Area,
                Lat = region.Lat,
                Long = region.Long,
                Name = region.Name,
                Population = region.Population

            };
            return Ok(regionDTO);
        }
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> updateRegionAsync([FromRoute] Guid id, [FromBody] Models.DTO.UpdateRegionRequest updateRegionRequest)
        {
            var region = new Models.Domain.Region
            {
                Code = updateRegionRequest.Code,
                Area = updateRegionRequest.Area,
                Lat = updateRegionRequest.Lat,
                Long = updateRegionRequest.Long,
                Name = updateRegionRequest.Name,
                Population = updateRegionRequest.Population

            };
            region = await regionReposetory.UpdateAsynd(id, region);
            if (region == null)
            {
                return null;
            }
            var regionDTO = new Models.DTO.Region
            {
                Id = region.Id,

                Code = region.Code,
                Area = region.Area,
                Lat = region.Lat,
                Long = region.Long,
                Name = region.Name,
                Population = region.Population
            };  
            return Ok (regionDTO);
        }
    }
}