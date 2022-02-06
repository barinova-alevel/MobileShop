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

        public async Task<PaginatedItems<Mobile>> GetByPageAsync(Specification<Mobile> filter, int pageIndex, int pageSize)
        {
            IQueryable<Mobile> query = _dbContext.Mobiles.Where(filter);

            var totalItems = await query.LongCountAsync();

            var itemsOnPage = await query.OrderBy(m => m.Name)
               .Include(i => i.Brand)
               .Include(i => i.OperationSystem)
               .Skip(pageSize * pageIndex)
               .Take(pageSize)
               .ToListAsync();

            return new PaginatedItems<Mobile>() { TotalCount = totalItems, Data = itemsOnPage };
        }

    }
}
