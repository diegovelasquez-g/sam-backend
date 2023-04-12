using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SAM.Domain.Entities;

namespace SAM.Infrastructure.Persistences.Contexts.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(e => e.CreatedDate).HasColumnType("datetime");

            builder.Property(e => e.Description)
                .HasMaxLength(200)
                .IsUnicode(false);

            builder.Property(e => e.ModifiedDate).HasColumnType("datetime");

            builder.Property(e => e.ProductCode)
                .HasMaxLength(20)
                .IsUnicode(false);

            builder.Property(e => e.ProductImage).IsUnicode(false);

            builder.Property(e => e.ProductName)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.UnitPrice).HasColumnType("decimal(19, 4)");

            builder.HasOne(d => d.Discount)
                .WithMany(p => p.Products)
                .HasForeignKey(d => d.DiscountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Products__Discou__5FB337D6");

            builder.HasOne(d => d.Status)
                .WithMany(p => p.Products)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Products__Status__5EBF139D"); ;
        }
    }
}
