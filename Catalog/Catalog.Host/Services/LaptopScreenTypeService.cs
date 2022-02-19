using AutoMapper;
using Catalog.Host.Data;
using Catalog.Host.Models.Dtos;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services.Interfaces;
using Infrastructure.Services;
using Infrastructure.Services.Interfaces;

namespace Catalog.Host.Services
{
    public class LaptopScreenTypeService : BaseDataService<ApplicationDbContext>, ILaptopScreenTypeService
    {
        private readonly ILaptopScreenTypeRepository _laptopScreenTypeRepository;
        private readonly IMapper _mapper;
        public LaptopScreenTypeService(
            IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<BaseDataService<ApplicationDbContext>> logger,
        ILaptopScreenTypeRepository laptopScreenTypeRepository,
        IMapper mapper)
        : base(dbContextWrapper, logger)
        {
            _laptopScreenTypeRepository = laptopScreenTypeRepository;
            _mapper = mapper;
        }

        public Task<int?> AddAsync(string screenType)
        {
            return ExecuteSafeAsync(() => _laptopScreenTypeRepository.Add(screenType));
        }

        public Task<int?> UpdateAsync(int id, string name)
        {
            return ExecuteSafeAsync(() => _laptopScreenTypeRepository.Update(id, name));
        }

        public Task<int?> RemoveAsync(int id)
        {
            return ExecuteSafeAsync(() => _laptopScreenTypeRepository.Remove(id));
        }
        public Task<List<LaptopScreenTypeDto>> GetAllAsync()
        {
            return ExecuteSafeAsync(async () =>
            {
                var screenTypes = await _laptopScreenTypeRepository.GetAllAsync();
                return screenTypes.Select(_ => _mapper.Map<LaptopScreenTypeDto>(_)).ToList();
            });
        }
    }
}
