using Catalog.Host.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catalog.Host.Data.EntityConfigurations
{
    public class MobileBrandEntityTypeConfiguration : IEntityTypeConfiguration<MobileBrand>
    {
        public void Configure(EntityTypeBuilder<MobileBrand> builder)
        {
            builder.ToTable("MobileBrand");

            builder.HasKey(mb => mb.Id);

            builder.Property(mb => mb.Id)
                .UseHiLo("mobilebrand_hilo")
                .IsRequired();

            builder.Property(mb => mb.Name)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
