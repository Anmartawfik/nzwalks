using Microsoft.EntityFrameworkCore;
using NZWalksapi.Models.Domain;

namespace NZWalksapi.Data
{
    public class NZWalksDbContext: DbContext
    {
        public NZWalksDbContext(DbContextOptions<NZWalksDbContext> options) :base(options)
        {
            

    }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }
        public DbSet<WalkDifficulty> WalkDifficulty { get; set; }


    }
}
