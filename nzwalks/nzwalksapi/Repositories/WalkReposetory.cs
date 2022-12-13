using Microsoft.EntityFrameworkCore;
using NZWalksapi.Data;
using NZWalksapi.Models.Domain;

namespace NZWalksapi.Repositories
{
    public class WalkReposetory :IWalkReposetory
    {
        private readonly NZWalksDbContext nZWalksDbContext;

        public WalkReposetory(NZWalksDbContext nZWalksDbContext)
        {
            this.nZWalksDbContext = nZWalksDbContext;
        }

        public Task<Walk> AddAsync(Walk walk)
        {
             nZWalksDbContext.AddAsync(walk);
             nZWalksDbContext.SaveChanges();
        }

        public async Task<IEnumerable<Walk>> GetAllAsync()
        {
             return await nZWalksDbContext.Walks.
             Include(x=>x.Region).
             Include(x=>x.WalkDifficulty).
             ToListAsync();
        }

        public async Task<Walk> GetAsync(Guid id)
        {
            return await nZWalksDbContext.Walks.
             Include(x=>x.Region).
             Include(x=>x.WalkDifficulty).
             FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
