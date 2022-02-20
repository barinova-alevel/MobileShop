using Catalog.Host.Data;
using Catalog.Host.Data.Entities;
using Infrastructure;
using Infrastructure.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Host.Repositories.Interfaces
{
    public class LaptopRepository : ILaptopRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ILogger<LaptopRepository> _logger;

        public LaptopRepository(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<LaptopRepository> logger)
        {
            _dbContext = dbContextWrapper.DbContext;
            _logger = logger;
        }

        public async Task<int?> Add(string name, string description, decimal price, string pictureFileName, int laptopBrandId, int screenTypeId, int availableStock, string sku)
        {
            var laptop = await _dbContext.AddAsync(new Laptop
            {
                Name = name,
                Description = description,
                Price = price,
                PictureFileName = pictureFileName,
                LaptopBrandId = laptopBrandId,
                ScreenTypeId = screenTypeId,
                AvailableStock = availableStock,
                Sku = sku
            });

            await _dbContext.SaveChangesAsync();

            return laptop.Entity.Id;
        }

        public async Task<int?> Update(int id, string name, string description, decimal price, string pictureFileName, int laptopBrandId, int screenTypeId, int availableStock)
        {
            var laptop = new Laptop
            {
                Id = id,
                Name = name,
                Description = description,
                Price = price,
                PictureFileName = pictureFileName,
                LaptopBrandId = laptopBrandId,
                ScreenTypeId = screenTypeId,
                AvailableStock = availableStock
            };

            _dbContext.Update(laptop);
            await _dbContext.SaveChangesAsync();

            return laptop.Id;
        }
        public async Task<Laptop?> GetById(int id)
        {
            return await _dbContext.Laptops
                .Include(i => i.LaptopBrand)
                .Include(i => i.ScreenType)
                .FirstOrDefaultAsync(_ => _.Id == id);
        }
        public Task<int?> Remove(int id)
        {
            return RepositoryHelper.Remove<Laptop>(_dbContext, id);
        }

        public async Task<PaginatedItems<Laptop>> GetByPageAsync(Specification<Laptop> filter, int pageIndex, int pageSize)
        {
            IQueryable<Laptop> query = _dbContext.Laptops.Where(filter);

            var totalItems = await query.LongCountAsync();

            var itemsOnPage = await query.OrderBy(l => l.Name)
               .Include(i => i.LaptopBrand)
               .Include(i => i.ScreenType)
               .Skip(pageSize * pageIndex)
               .Take(pageSize)
               .ToListAsync();

            return new PaginatedItems<Laptop>() { TotalCount = totalItems, Data = itemsOnPage };
        }

    }
}
