using Catalog.Host.Data.Entities;

namespace Catalog.Host.Repositories.Interfaces
{
    public interface IMobileBrandRepository
    {
        Task<int?> Add(string brand);

        Task<int?> Update(int id, string name);

        Task<int?> Remove(int id);

        Task<List<MobileBrand>> GetAllAsync();
    }
}
