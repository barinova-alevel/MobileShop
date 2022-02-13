using Catalog.Host.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catalog.Host.Data.EntityConfigurations
{
    public class LaptopEntityTypeConfiguration : IEntityTypeConfiguration<Laptop>
    {
        public void Configure(EntityTypeBuilder<Laptop> builder)
        {
            builder.ToTable("Laptop");

            builder.Property(l => l.Id)
                .UseHiLo("laptopes_hilo")
                .IsRequired();

            builder.Property(l => l.Name)
                .IsRequired(true)
                .HasMaxLength(150);

            builder.Property(l => l.Price)
                .IsRequired(true);

            builder.Property(l => l.PictureFileName)
                .IsRequired(false);

            builder.Property(l => l.Description)
                .IsRequired(false);

            builder.HasOne(l => l.LaptopBrand)
                .WithMany()
                .HasForeignKey(l => l.LaptopBrandId);

            builder.HasOne(l => l.ScreenType)
                .WithMany()
                .HasForeignKey(l => l.ScreenTypeId);

            builder.Property(l => l.AvailableStock)
                .IsRequired(true);
        }
    }
}
