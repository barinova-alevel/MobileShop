using Catalog.Host.Data.Entities;
using Catalog.Host.Models.Dtos;
using Catalog.Host.Models.Response;

namespace Catalog.Host.Services.Interfaces
{
    public interface IMobileService
    {
        Task<int?> AddAsync(string name, string description, decimal price, string pictureFileName, int brandId, int operationSystemId, int availableStock);
        Task<int?> UpdateAsync(int id, string name, string description, decimal price, string pictureFileName, int brandId, int operationSystemId, int availableStock);
        Task<int?> RemoveAsync(int id);
        Task<PaginatedItemsResponse<MobileDto>?> GetMobileAsync(MobileFilter filter, int pageSize, int pageIndex);

    }
}
