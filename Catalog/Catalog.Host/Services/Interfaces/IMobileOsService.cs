using Catalog.Host.Models.Dtos;

namespace Catalog.Host.Services.Interfaces
{
    public interface IMobileOsService
    {
        Task<int?> AddAsync(string os);
        Task<int?> UpdateAsync(int id, string os);
        Task<int?> RemoveAsync(int id);
        Task<List<MobileOsDto>> GetAllAsync();
    }
}
