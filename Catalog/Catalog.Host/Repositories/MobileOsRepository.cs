using Catalog.Host.Data;
using Catalog.Host.Data.Entities;
using Infrastructure.Services.Interfaces;

namespace Catalog.Host.Repositories
{
    public class MobileOsRepository : IMobileOsRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public MobileOsRepository(IDbContextWrapper<ApplicationDbContext> dbContext)
        {
            this._dbContext = dbContext.DbContext;
        }

        public async Task<int?> Add(string mobileOsName)
        {
            var os = await _dbContext.AddAsync(new MobileOs
            {
                Name = mobileOsName
            });

            await _dbContext.SaveChangesAsync();

            return os.Entity.Id;
        }

        public async Task<int?> Update(int id, string name)
        {
            var os = new MobileOs
            {
                Id = id,
                Name = name
            };

            _dbContext.Update(os);
            await _dbContext.SaveChangesAsync();

            return os.Id;
        }

        public Task<int?> Remove(int id)
        {
            return RepositoryHelper.Remove<MobileOs>(_dbContext, id);
        }
    }
}
