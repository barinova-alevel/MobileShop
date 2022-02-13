using Catalog.Host.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catalog.Host.Data.EntityConfigurations
{
    public class LaptopBrandEntityTypeConfiguration : IEntityTypeConfiguration<LaptopBrand>
    {
        public void Configure(EntityTypeBuilder<LaptopBrand> builder)
        {
            builder.ToTable("LaptopBrand");

            builder.HasKey(lb => lb.Id);

            builder.Property(lb => lb.Id)
                .UseHiLo("laptopbrand_hilo")
                .IsRequired();

            builder.Property(lb => lb.Name)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
