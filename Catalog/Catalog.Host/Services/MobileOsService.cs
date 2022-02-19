using AutoMapper;
using Catalog.Host.Data;
using Catalog.Host.Models.Dtos;
using Catalog.Host.Repositories;
using Catalog.Host.Services.Interfaces;
using Infrastructure.Services;
using Infrastructure.Services.Interfaces;

namespace Catalog.Host.Services
{
    public class MobileOsService : BaseDataService<ApplicationDbContext>,
       IMobileOsService
    {
        private readonly IMobileOsRepository _mobileOsRepository;
        private readonly IMapper _mapper;
        public MobileOsService(
            IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<BaseDataService<ApplicationDbContext>> logger,
        IMobileOsRepository mobileOsRepository,
        IMapper mapper)
        : base(dbContextWrapper, logger)
        {
            _mobileOsRepository = mobileOsRepository;
            _mapper = mapper;
        }

        public Task<int?> AddAsync(string os)
        {
            return ExecuteSafeAsync(() => _mobileOsRepository.Add(os));
        }

        public Task<int?> UpdateAsync(int id, string name)
        {
            return ExecuteSafeAsync(() => _mobileOsRepository.Update(id, name));
        }

        public Task<int?> RemoveAsync(int id)
        {
            return ExecuteSafeAsync(() => _mobileOsRepository.Remove(id));
        }

        public Task<List<MobileOsDto>> GetAllAsync()
        {
            return ExecuteSafeAsync(async () =>
            {
                var brands = await _mobileOsRepository.GetAllAsync();
                return brands.Select(_ => _mapper.Map<MobileOsDto>(_)).ToList();
            });
        }
    }
}
