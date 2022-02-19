using Catalog.Host.Data.Entities;

namespace Catalog.Host.Repositories
{
    public interface IMobileOsRepository
    {
        Task<int?> Add(string os);

        Task<int?> Update(int id, string name);

        Task<int?> Remove(int id);

        Task<List<MobileOs>> GetAllAsync();
    }
}
