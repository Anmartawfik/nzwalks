using NZWalksapi.Models.Domain;

namespace NZWalksapi.Repositories
{
    public interface IRegionReposetory
    {
    Task<IEnumerable <Region>> GetAllAsync();
    }
}
