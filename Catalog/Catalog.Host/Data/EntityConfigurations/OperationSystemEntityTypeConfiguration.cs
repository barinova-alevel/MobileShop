using Catalog.Host.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catalog.Host.Data.EntityConfigurations
{
    public class OperationSystemEntityTypeConfiguration : IEntityTypeConfiguration<MobileOs>
    {
        public void Configure(EntityTypeBuilder<MobileOs> builder)
        {
            builder.ToTable("OperationSystem");

            builder.HasKey(os => os.Id);

            builder.Property(os => os.Id)
                .UseHiLo("operationsystem_hilo")
                .IsRequired();

            builder.Property(os => os.Name)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
