
using Catalog.Host.Models.Dtos;

namespace Catalog.Host.Services.Interfaces
{
    public interface ILaptopScreenTypeService
    {
        Task<int?> AddAsync(string screenType);
        Task<int?> UpdateAsync(int id, string name);
        Task<int?> RemoveAsync(int id);
        Task<List<LaptopScreenTypeDto>> GetAllAsync();
    }
}
