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
        public async Task<IEnumerable<Region>> GetAllAsync()
            
        {
            return await nZWalksDbContext.Regions.ToListAsync();
        }
    }
}
