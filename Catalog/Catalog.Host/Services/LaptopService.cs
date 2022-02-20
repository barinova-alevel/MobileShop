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
    public class LaptopService : BaseDataService<ApplicationDbContext>, ILaptopService
    {
        private readonly ILaptopRepository _laptopRepository;
        private readonly IMapper _mapper;

        public LaptopService(
            IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
            ILogger<BaseDataService<ApplicationDbContext>> logger,
            ILaptopRepository laptopRepository,
            IMapper mapper)
            : base(dbContextWrapper, logger)
        {
            _laptopRepository = laptopRepository;
            this._mapper = mapper;
        }

        public Task<int?> AddAsync(string name, string description, decimal price, string pictureFileName, int laptopBrandId, int screenTypeId, int availableStock, string sku)
        {
            return ExecuteSafeAsync(() => _laptopRepository.Add(name, description, price, pictureFileName, laptopBrandId, screenTypeId, availableStock, sku));
        }

        public Task<int?> UpdateAsync(int id, string name, string description, decimal price, string pictureFileName, int laptopBrandId, int screenTypeId, int availableStock)
        {
            return ExecuteSafeAsync(() => _laptopRepository.Update(id, name, description, price, pictureFileName, laptopBrandId, screenTypeId, availableStock));
        }

        public Task<int?> RemoveAsync(int id)
        {
            return ExecuteSafeAsync(() => _laptopRepository.Remove(id));
        }

        public async Task<PaginatedItemsResponse<LaptopDto>?> GetLaptopsAsync(LaptopFilter filter, int pageSize, int pageIndex)
        {
            var spec = Specification.New<Laptop>(_ => true);
            if (filter.LaptopBrandId.HasValue)
            {
                spec &= _ => _.LaptopBrandId == filter.LaptopBrandId;
            }
            if (filter.ScreenTypeId.HasValue)
            {
                spec &= _ => _.ScreenTypeId == filter.ScreenTypeId;
            }

            var result = await _laptopRepository.GetByPageAsync(spec, pageIndex, pageSize);
            if (result == null)
            {
                return null;
            }

            return new PaginatedItemsResponse<LaptopDto>()
            {
                Count = result.TotalCount,
                Data = result.Data.Select(s => _mapper.Map<LaptopDto>(s)).ToList(),
                PageIndex = pageIndex,
                PageSize = pageSize
            };
        }

        public async Task<LaptopDto?> GetById(int id)
        {
            var laptop = await _laptopRepository.GetById(id);
            if (laptop == null)
            {
                return null;
            }

            return _mapper.Map<LaptopDto>(laptop);
        }
    }
}
