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
        public DbSet<MobileBrand> MobileBrands { get; set; } = null!;
        public DbSet<MobileOs> OperationSystems { get; set; } = null!;
        public DbSet<Laptop> Laptops { get; set; } = null!;
        public DbSet<LaptopBrand> LaptopBrands { get; set; } = null!;
        public DbSet<LaptopScreenType> ScreenTypes { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new MobileEntityTypeConfiguration());
            builder.ApplyConfiguration(new MobileBrandEntityTypeConfiguration());
            builder.ApplyConfiguration(new OperationSystemEntityTypeConfiguration());
            builder.ApplyConfiguration(new LaptopEntityTypeConfiguration());
            builder.ApplyConfiguration(new LaptopBrandEntityTypeConfiguration());
            builder.ApplyConfiguration(new ScreenTypeEntityTypeConfiguration());
        }
    }
}