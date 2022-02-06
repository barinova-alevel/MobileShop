using Catalog.Host.Data.Entities;
using Catalog.Host.Data.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Host.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : base(options)
        {
        }

        public DbSet<Mobile> Mobiles { get; set; } = null!;
        public DbSet<Brand> Brands { get; set; } = null!;
        public DbSet<OperationSystem> OperationSystems { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new MobileEntityTypeConfiguration());
            builder.ApplyConfiguration(new BrandEntityTypeConfiguration());
            builder.ApplyConfiguration(new OperationSystemEntityTypeConfiguration());
        }
    }
}
