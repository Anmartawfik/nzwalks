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

        public RegionsController(IRegionReposetory regionReposetory ,IMapper  mapper)
        {
            this.regionReposetory = regionReposetory;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> getAllRegions()
        {

            var regions = await  regionReposetory.GetAllAsync();
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
    }
}
