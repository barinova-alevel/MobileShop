using Catalog.Host.Data;
using Catalog.Host.Data.Entities;

namespace Catalog.Host.Repositories
{
    public class RepositoryHelper
    {

        public static async Task<int?> Remove<T>(ApplicationDbContext dbContext, int id)
            where T : IBaseEntity, new()
        {
            dbContext.Remove(new T { Id = id });
            await dbContext.SaveChangesAsync();
            return id;
        }
    }
}
