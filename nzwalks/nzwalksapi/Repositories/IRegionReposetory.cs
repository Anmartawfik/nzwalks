using NZWalksapi.Models.Domain;

namespace NZWalksapi.Repositories
{
    public interface IRegionReposetory
    {
        Task<IEnumerable<Region>> GetAllAsync();
        Task<Region> GetAsync(Guid id); //contract

        Task<Region> AddAsync(Region region);

        Task <Region> DeleteAsync(Guid id);

        Task<Region> UpdateAsynd (Guid id, Region region);

    }

}
