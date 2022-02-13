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

namespace Catalog.Host.Services
{
    public class MobileService : BaseDataService<ApplicationDbContext>, IMobileService
    {
        private readonly IMobileRepository _mobileRepository;
        private readonly IMapper _mapper;

        public MobileService(
            IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
            ILogger<BaseDataService<ApplicationDbContext>> logger,
            IMobileRepository mobileRepository,
            IMapper mapper)
            : base(dbContextWrapper, logger)
        {
            _mobileRepository = mobileRepository;
            this._mapper = mapper;
        }

        public Task<int?> AddAsync(string name, string description, decimal price, string pictureFileName, int brandId, int operationSystemId, int availableStock)
        {
            return ExecuteSafeAsync(() => _mobileRepository.Add(name, description, price, pictureFileName, brandId, operationSystemId, availableStock));
        }

        public Task<int?> UpdateAsync(int id, string name, string description, decimal price, string pictureFileName, int brandId, int operationSystemId, int availableStock)
        {
            return ExecuteSafeAsync(() => _mobileRepository.Update(id, name, description, price, pictureFileName, brandId, operationSystemId, availableStock));
        }

        public Task<int?> RemoveAsync(int id)
        {
            return ExecuteSafeAsync(() => _mobileRepository.Remove(id));
        }
        public async Task<PaginatedItemsResponse<MobileDto>?> GetMobileAsync(MobileFilter filter, int pageSize, int pageIndex)
        {
            var spec = Specification.New<Mobile>(_ => true);
            if (filter.MobileBrandId.HasValue)
            {
                spec &= _ => _.MobileBrandId == filter.MobileBrandId;
            }
            if (filter.OperationSystemId.HasValue)
            {
                spec &= _ => _.OperationSystemId == filter.OperationSystemId;
            }

            var result = await _mobileRepository.GetByPageAsync(spec, pageIndex, pageSize);
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
}
