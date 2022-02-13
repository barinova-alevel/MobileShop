using AutoMapper;
using Catalog.Host.Data;
using Catalog.Host.Models.Dtos;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services.Interfaces;
using Infrastructure.Services;
using Infrastructure.Services.Interfaces;

namespace Catalog.Host.Services
{
    public class MobileBrandService : BaseDataService<ApplicationDbContext>,
       IMobileBrandService
    {
        private readonly IMobileBrandRepository _brandRepository;
        private readonly IMapper _mapper;
        public MobileBrandService(
            IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<BaseDataService<ApplicationDbContext>> logger,
        IMobileBrandRepository brandRepository,
        IMapper mapper)
        : base(dbContextWrapper, logger)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
        }

        public Task<int?> AddAsync(string brand)
        {
            return ExecuteSafeAsync(() => _brandRepository.Add(brand));
        }

        public Task<int?> UpdateAsync(int id, string name)
        {
            return ExecuteSafeAsync(() => _brandRepository.Update(id, name));
        }

        public Task<int?> RemoveAsync(int id)
        {
            return ExecuteSafeAsync(() => _brandRepository.Remove(id));
        }

        public Task<List<MobileBrandDto>> GetAllAsync()
        {
            return ExecuteSafeAsync(async () =>
            {
                var brands = await _brandRepository.GetAllAsync();
                return brands.Select(_ => _mapper.Map<MobileBrandDto>(_)).ToList();
            });
        }
    }
}
