using Catalog.Host.Data;
using Catalog.Host.Data.Entities;
using Infrastructure;

namespace Catalog.Host.Repositories.Interfaces;

public interface IMobileRepository
{
    Task<PaginatedItems<Mobile>> GetByPageAsync(Specification<Mobile> filter, int pageIndex, int pageSize);
}