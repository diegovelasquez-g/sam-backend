using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SAM.Domain.Entities;

namespace SAM.Infrastructure.Persistences.Contexts.Configurations
{
    public class CartsItemConfiguration : IEntityTypeConfiguration<CartsItem>
    {
        public void Configure(EntityTypeBuilder<CartsItem> builder)
        {
            builder.HasKey(e => e.CartItemId)
                    .HasName("PK__CartsIte__488B0B0ABDEACDB7");

            builder.Property(e => e.ItemTotal).HasColumnType("decimal(19, 4)");

            builder.HasOne(d => d.Cart)
                .WithMany(p => p.CartsItems)
                .HasForeignKey(d => d.CartId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CartsItem__CartI__6754599E");

            builder.HasOne(d => d.Product)
                .WithMany(p => p.CartsItems)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CartsItem__Produ__68487DD7");
        }
    }
}
