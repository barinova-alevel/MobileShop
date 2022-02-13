using Catalog.Host.Models.Dtos;
using Catalog.Host.Models.Response;

namespace Catalog.Host.Services.Interfaces
{
    public interface ILaptopService
    {
        Task<int?> AddAsync(string name, string description, decimal price, string pictureFileName, int laptopBrandId, int screenTypeId, int availableStock);
        Task<int?> UpdateAsync(int id, string name, string description, decimal price, string pictureFileName, int laptopBrandId, int screenTypeId, int availableStock);
        Task<int?> RemoveAsync(int id);
        Task<PaginatedItemsResponse<LaptopDto>?> GetLaptopsAsync(LaptopFilter filter, int pageSize, int pageIndex);
    }
}
