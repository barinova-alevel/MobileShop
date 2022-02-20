using Catalog.Host.Data;
using Catalog.Host.Data.Entities;
using Catalog.Host.Repositories.Interfaces;
using Infrastructure;
using Infrastructure.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Host.Repositories
{
    public class MobileRepository : IMobileRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ILogger<MobileRepository> _logger;

        public MobileRepository(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<MobileRepository> logger)
        {
            _dbContext = dbContextWrapper.DbContext;
            _logger = logger;
        }

        public async Task<int?> Add(string name, string description, decimal price, string pictureFileName, int brandId, int operationSystemId, int availableStock, string sku)
        {
            var mobile = await _dbContext.AddAsync(new Mobile
            {
                Name = name,
                Description = description,
                Price = price,
                PictureFileName = pictureFileName,
                MobileBrandId = brandId,
                OperationSystemId = operationSystemId,
                AvailableStock = availableStock,
                Sku = sku
            });

            await _dbContext.SaveChangesAsync();

            return mobile.Entity.Id;
        }

        public async Task<int?> Update(int id, string name, string description, decimal price, string pictureFileName, int brandId, int operationSystemId, int availableStock)
        {
            var mobile = new Mobile
            {
                Id = id,
                Name = name,
                Description = description,
                Price= price,
                PictureFileName= pictureFileName,
                MobileBrandId= brandId,
                OperationSystemId= operationSystemId,
                AvailableStock= availableStock
            };

            _dbContext.Update(mobile);
            await _dbContext.SaveChangesAsync();

            return mobile.Id;
        }

        public async Task<Mobile?> GetById(int id)
        {
            return await _dbContext.Mobiles
                .Include(i => i.MobileBrand)
                .Include(i => i.OperationSystem)
                .FirstOrDefaultAsync(_ => _.Id == id);
        }

        public Task<int?> Remove(int id)
        {
            return RepositoryHelper.Remove<Mobile>(_dbContext, id);
        }

        public async Task<PaginatedItems<Mobile>> GetByPageAsync(Specification<Mobile> filter, int pageIndex, int pageSize)
        {
            IQueryable<Mobile> query = _dbContext.Mobiles.Where(filter);

            var totalItems = await query.LongCountAsync();

            var itemsOnPage = await query.OrderBy(m => m.Name)
               .Include(i => i.MobileBrand)
               .Include(i => i.OperationSystem)
               .Skip(pageSize * pageIndex)
               .Take(pageSize)
               .ToListAsync();

            return new PaginatedItems<Mobile>() { TotalCount = totalItems, Data = itemsOnPage };
        }

    }
}
