using Catalog.Host.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catalog.Host.Data.EntityConfigurations
{
    public class ScreenTypeEntityTypeConfiguration : IEntityTypeConfiguration<LaptopScreenType>
    {
        public void Configure(EntityTypeBuilder<LaptopScreenType> builder)
        {
            builder.ToTable("ScreenType");

            builder.HasKey(st => st.Id);

            builder.Property(st => st.Id)
                .UseHiLo("screentype_hilo")
                .IsRequired();

            builder.Property(st => st.Name)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
