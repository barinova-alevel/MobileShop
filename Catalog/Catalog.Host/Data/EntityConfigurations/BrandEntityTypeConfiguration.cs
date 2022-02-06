using Catalog.Host.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catalog.Host.Data.EntityConfigurations
{
    public class BrandEntityTypeConfiguration : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.ToTable("Brand");

            builder.HasKey(b => b.Id);

            builder.Property(b => b.Id)
                .UseHiLo("brand_hilo")
                .IsRequired();

            builder.Property(b => b.Name)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
