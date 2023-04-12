using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SAM.Domain.Entities;

namespace SAM.Infrastructure.Persistences.Contexts.Configurations
{
    public class ProductsProviderConfiguration : IEntityTypeConfiguration<ProductsProvider>
    {
        public void Configure(EntityTypeBuilder<ProductsProvider> builder)
        {
            builder.ToTable("Products_Providers");

            builder.HasOne(d => d.Product)
                .WithMany(p => p.ProductsProviders)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Products___Produ__6477ECF3");

            builder.HasOne(d => d.Provider)
                .WithMany(p => p.ProductsProviders)
                .HasForeignKey(d => d.ProviderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Products___Provi__656C112C");
        }
    }
}
