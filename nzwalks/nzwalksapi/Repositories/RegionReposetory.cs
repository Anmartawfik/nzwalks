using Microsoft.EntityFrameworkCore;
using NZWalksapi.Data;
using NZWalksapi.Models.Domain;

namespace NZWalksapi.Repositories
{
    public class RegionReposetory : IRegionReposetory
    {
        private readonly NZWalksDbContext nZWalksDbContext;

        public RegionReposetory(NZWalksDbContext nZWalksDbContext)
        {
            this.nZWalksDbContext = nZWalksDbContext;
        }

        public async Task<Region> AddAsync(Region region)
        {
            region.Id = Guid.NewGuid();
            await nZWalksDbContext.AddAsync(region);
            await nZWalksDbContext.SaveChangesAsync();
            return region;
        }

        public async Task<Region> DeleteAsync(Guid id)
        {
            var region = await nZWalksDbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
            if (region == null) 
            { 
                return null;
            }
            nZWalksDbContext.Regions.Remove(region);
            await nZWalksDbContext.SaveChangesAsync();
            return(region);
        }

        public async Task<IEnumerable<Region>> GetAllAsync()

        {
            return await nZWalksDbContext.Regions.ToListAsync();
        }

        public async Task<Region> GetAsync(Guid id)
        {
            return await nZWalksDbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Region> UpdateAsynd(Guid id, Region region)
        {
            var existingRegion = await  nZWalksDbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
            if (existingRegion == null) 
            {
                return null;
            }
            existingRegion.Code=region.Code;
            existingRegion.Area=region.Area;
            existingRegion.Name=region.Name;
            existingRegion.Lat=region.Lat;
            existingRegion.Long=region.Long;
            existingRegion.Population=region.Population;
            await nZWalksDbContext.SaveChangesAsync();
            return(existingRegion);
        }
    }
}
