using Catalog.Host.Data;
using Catalog.Host.Data.Entities;
using Infrastructure;

namespace Catalog.Host.Repositories.Interfaces;

public interface IMobileRepository
{
    Task<int?> Add(string name, string description, decimal price, string pictureFileName, int brandId, int operationSystemId, int availableStock, string sku);
    Task<int?> Update(int id, string name, string description, decimal price, string pictureFileName, int brandId, int operationSystemId, int availableStock);
    Task<int?> Remove(int id);
    Task<Mobile?> GetById(int id);
    Task<PaginatedItems<Mobile>> GetByPageAsync(Specification<Mobile> filter, int pageIndex, int pageSize);
}