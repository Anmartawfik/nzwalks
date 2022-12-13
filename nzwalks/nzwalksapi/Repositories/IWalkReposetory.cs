using NZWalksapi.Models.Domain;

namespace NZWalksapi.Repositories
{
    public interface IWalkReposetory
    {
        Task<IEnumerable<Walk>> GetAllAsync();
       Task<Walk> GetAsync(Guid id); //contract

        Task<Walk> AddAsync(Walk walk);

        //Task <Walk> DeleteAsync(Guid id);

        //Task<Walk> UpdateAsynd (Guid id, Walk walk);

    }

}
