using Catalog.Host.Data;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services.Interfaces;
using Infrastructure.Services;
using Infrastructure.Services.Interfaces;

namespace Catalog.Host.Services
{
    public class LaptopScreenTypeService : BaseDataService<ApplicationDbContext>, ILaptopScreenTypeService
    {
        private readonly ILaptopScreenTypeRepository _laptopScreenTypeRepository;
        public LaptopScreenTypeService(
            IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<BaseDataService<ApplicationDbContext>> logger,
        ILaptopScreenTypeRepository laptopScreenTypeRepository)
        : base(dbContextWrapper, logger)
        {
            _laptopScreenTypeRepository = laptopScreenTypeRepository;
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
    }
}
