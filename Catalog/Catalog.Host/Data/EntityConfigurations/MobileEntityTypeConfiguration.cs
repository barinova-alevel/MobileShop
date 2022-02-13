using Catalog.Host.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catalog.Host.Data.EntityConfigurations
{
    public class MobileEntityTypeConfiguration : IEntityTypeConfiguration<Mobile>
    {
        public void Configure(EntityTypeBuilder<Mobile> builder)
        {
            builder.ToTable("Mobile");

            builder.Property(m => m.Id)
                .UseHiLo("mobiles_hilo")
                .IsRequired();

            builder.Property(m => m.Name)
                .IsRequired(true)
                .HasMaxLength(150);

            builder.Property(m => m.Price)
                .IsRequired(true);

            builder.Property(m => m.PictureFileName)
                .IsRequired(false);

            builder.Property(m => m.Description)
                .IsRequired(false);

            builder.HasOne(m => m.MobileBrand)
                .WithMany()
                .HasForeignKey(m => m.MobileBrandId);

            builder.HasOne(m => m.OperationSystem)
                .WithMany()
                .HasForeignKey(m => m.OperationSystemId);

            builder.Property(m => m.AvailableStock)
                .IsRequired(true);
        }
    }
}
