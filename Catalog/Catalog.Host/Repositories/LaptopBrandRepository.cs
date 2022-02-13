using Catalog.Host.Data;
using Catalog.Host.Data.Entities;
using Catalog.Host.Repositories.Interfaces;
using Infrastructure.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Host.Repositories
{
    public class LaptopBrandRepository : ILaptopBrandRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public LaptopBrandRepository(IDbContextWrapper<ApplicationDbContext> dbContext)
        {
            this._dbContext = dbContext.DbContext;
        }

        public async Task<int?> Add(string brandName)
        {
            var brand = await _dbContext.AddAsync(new LaptopBrand
            {
                Name = brandName
            });

            await _dbContext.SaveChangesAsync();

            return brand.Entity.Id;
        }

        public async Task<int?> Update(int id, string name)
        {
            var brand = new LaptopBrand
            {
                Id = id,
                Name = name
            };

            _dbContext.Update(brand);
            await _dbContext.SaveChangesAsync();

            return brand.Id;
        }

        public Task<int?> Remove(int id)
        {
            return RepositoryHelper.Remove<LaptopBrand>(_dbContext, id);
        }

        public Task<List<LaptopBrand>> GetAllAsync()
        {
            return _dbContext.LaptopBrands.ToListAsync();
        }
    }
}
