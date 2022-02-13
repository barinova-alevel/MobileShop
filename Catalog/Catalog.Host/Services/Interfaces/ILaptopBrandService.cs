using Catalog.Host.Models.Dtos;

namespace Catalog.Host.Services.Interfaces
{
    public interface ILaptopBrandService
    {
        Task<int?> AddAsync(string brand);
        Task<int?> UpdateAsync(int id, string brand);
        Task<int?> RemoveAsync(int id);
        Task<List<LaptopBrandDto>> GetAllAsync();
    }
}
