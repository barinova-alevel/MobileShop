using Catalog.Host.Data.Entities;

namespace Catalog.Host.Repositories.Interfaces
{
    public interface ILaptopBrandRepository
    {
        Task<int?> Add(string brand);

        Task<int?> Update(int id, string name);

        Task<int?> Remove(int id);
        Task<List<LaptopBrand>> GetAllAsync();

    }
}
