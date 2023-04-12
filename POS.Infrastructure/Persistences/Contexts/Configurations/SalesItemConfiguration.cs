using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SAM.Domain.Entities;

namespace SAM.Infrastructure.Persistences.Contexts.Configurations
{
    public class SalesItemConfiguration : IEntityTypeConfiguration<SalesItem>
    {
        public void Configure(EntityTypeBuilder<SalesItem> builder)
        {
            builder.HasKey(e => e.SaleItemId)
                    .HasName("PK__SalesIte__C60594011C72B9FB");

            builder.Property(e => e.ItemTotal).HasColumnType("decimal(19, 4)");

            builder.HasOne(d => d.Product)
                .WithMany(p => p.SalesItems)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SalesItem__Produ__6B24EA82");

            builder.HasOne(d => d.Sale)
                .WithMany(p => p.SalesItems)
                .HasForeignKey(d => d.SaleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SalesItem__SaleI__6A30C649");
        }
    }
}
