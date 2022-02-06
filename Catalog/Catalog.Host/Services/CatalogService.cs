using AutoMapper;
using Catalog.Host.Data;
using Catalog.Host.Data.Entities;
using Catalog.Host.Models.Dtos;
using Catalog.Host.Models.Response;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services.Interfaces;
using Infrastructure;
using Infrastructure.Services;
using Infrastructure.Services.Interfaces;

namespace Catalog.Host.Services;

public class CatalogService : BaseDataService<ApplicationDbContext>, ICatalogService
{
    private readonly IMobileRepository _catalogItemRepository;
    private readonly IMapper _mapper;

    public CatalogService(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<BaseDataService<ApplicationDbContext>> logger,
        IMobileRepository catalogItemRepository,
        IMapper mapper)
        : base(dbContextWrapper, logger)
    {
        _catalogItemRepository = catalogItemRepository;
        _mapper = mapper;
    }

    public async Task<PaginatedItemsResponse<MobileDto>?> GetCatalogItemsAsync(MobileFilter filter, int pageSize, int pageIndex)
    {
        var spec = Specification.New<Mobile>(_ => true);
        if (filter.BrandId.HasValue)
        {
            spec &= _ => _.BrandId == filter.BrandId;
        }
        if (filter.OperationSystemId.HasValue)
        {
            spec &= _ => _.OperationSystemId == filter.OperationSystemId;
        }

        var result = await _catalogItemRepository.GetByPageAsync(spec, pageIndex, pageSize);
        if (result == null)
        {
            return null;
        }

        return new PaginatedItemsResponse<MobileDto>()
        {
            Count = result.TotalCount,
            Data = result.Data.Select(s => _mapper.Map<MobileDto>(s)).ToList(),
            PageIndex = pageIndex,
            PageSize = pageSize
        };
    }
}