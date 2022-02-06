using Catalog.Host.Models.Dtos;
using Catalog.Host.Models.Response;

namespace Catalog.Host.Services.Interfaces;

public interface ICatalogService
{
    Task<PaginatedItemsResponse<MobileDto>?> GetCatalogItemsAsync(MobileFilter filter, int pageSize, int pageIndex);
}