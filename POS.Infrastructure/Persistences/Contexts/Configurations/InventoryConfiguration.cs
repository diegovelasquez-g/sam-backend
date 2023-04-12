using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SAM.Domain.Entities;

namespace SAM.Infrastructure.Persistences.Contexts.Configurations
{
    public class InventoryConfiguration : IEntityTypeConfiguration<Inventory>
    {
        public void Configure(EntityTypeBuilder<Inventory> builder)
        {
            builder.HasIndex(e => e.ProductId, "UQ__Inventor__B40CC6CCDE8492A3")
                    .IsUnique();

            builder.Property(e => e.CreatedDate).HasColumnType("datetime");

            builder.Property(e => e.EntryDate).HasColumnType("datetime");

            builder.Property(e => e.ModifiedDate).HasColumnType("datetime");

            builder.Property(e => e.WithdrawalDate).HasColumnType("datetime");

            builder.HasOne(d => d.Product)
                .WithOne(p => p.Inventory)
                .HasForeignKey<Inventory>(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Inventori__Produ__628FA481");
        }
    }
}
