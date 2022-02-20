using Catalog.Host.Data;
using Catalog.Host.Data.Entities;
using Infrastructure;

namespace Catalog.Host.Repositories.Interfaces
{
    public interface ILaptopRepository
    {
        Task<int?> Add(string name, string description, decimal price, string pictureFileName, int laptopBrandId, int screenTypeId, int availableStock, string sku);
        Task<int?> Update(int id, string name, string description, decimal price, string pictureFileName, int laptopBrandId, int screenTypeId, int availableStock);
        Task<int?> Remove(int id);
        Task<Laptop?> GetById(int id);
        Task<PaginatedItems<Laptop>> GetByPageAsync(Specification<Laptop> filter, int pageIndex, int pageSize);

    }
}
