using Catalog.Host.Data;
using Catalog.Host.Data.Entities;
using Catalog.Host.Repositories.Interfaces;
using Infrastructure.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Host.Repositories
{
    public class LaptopScreenTypeRepository : ILaptopScreenTypeRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public LaptopScreenTypeRepository(IDbContextWrapper<ApplicationDbContext> dbContext)
        {
            this._dbContext = dbContext.DbContext;
        }

        public async Task<int?> Add(string screenTypeName)
        {
            var screenType = await _dbContext.AddAsync(new LaptopScreenType
            {
                Name = screenTypeName
            });

            await _dbContext.SaveChangesAsync();

            return screenType.Entity.Id;
        }

        public async Task<int?> Update(int id, string name)
        {
            var screenType = new LaptopScreenType
            {
                Id = id,
                Name = name
            };

            _dbContext.Update(screenType);
            await _dbContext.SaveChangesAsync();

            return screenType.Id;
        }

        public Task<int?> Remove(int id)
        {
            return RepositoryHelper.Remove<LaptopScreenType>(_dbContext, id);
        }

        public Task<List<LaptopScreenType>> GetAllAsync()
        {
            return _dbContext.ScreenTypes.ToListAsync();
        }
    }
}
