using AutoMapper;
using Catalog.Host.Data;
using Catalog.Host.Models.Dtos;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services.Interfaces;
using Infrastructure.Services;
using Infrastructure.Services.Interfaces;

namespace Catalog.Host.Services
{
    public class LaptopBrandService : BaseDataService<ApplicationDbContext>, ILaptopBrandService
    {
        private readonly ILaptopBrandRepository _laptopBrandRepository;
        private readonly IMapper _mapper;

        public LaptopBrandService(
            IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
            ILogger<BaseDataService<ApplicationDbContext>> logger,
            ILaptopBrandRepository laptopBrandRepository,
            IMapper mapper)
        : base(dbContextWrapper, logger)
        {
            _laptopBrandRepository = laptopBrandRepository;
            _mapper = mapper;
        }

        public Task<int?> AddAsync(string brand)
        {
            return ExecuteSafeAsync(() => _laptopBrandRepository.Add(brand));
        }

        public Task<int?> UpdateAsync(int id, string name)
        {
            return ExecuteSafeAsync(() => _laptopBrandRepository.Update(id, name));
        }

        public Task<int?> RemoveAsync(int id)
        {
            return ExecuteSafeAsync(() => _laptopBrandRepository.Remove(id));
        }

        public Task<List<LaptopBrandDto>> GetAllAsync()
        {
            return ExecuteSafeAsync(async () =>
            {
                var brands = await _laptopBrandRepository.GetAllAsync();
                return brands.Select(_ => _mapper.Map<LaptopBrandDto>(_)).ToList();
            });
        }
    }
}
