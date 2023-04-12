using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SAM.Domain.Entities;

namespace SAM.Infrastructure.Persistences.Contexts.Configurations
{
    public class DeliveryConfiguration : IEntityTypeConfiguration<Delivery>
    {
        public void Configure(EntityTypeBuilder<Delivery> builder)
        {
            builder.HasIndex(e => e.SaleId, "UQ__Deliveri__1EE3C3FEF120FE40")
                    .IsUnique();

            builder.Property(e => e.DueDate).HasColumnType("datetime");

            builder.Property(e => e.TrackingNumber)
                .HasMaxLength(20)
                .IsUnicode(false);

            builder.HasOne(d => d.Address)
                .WithMany(p => p.Deliveries)
                .HasForeignKey(d => d.AddressId)
                .HasConstraintName("FK__Deliverie__Addre__70DDC3D8");

            builder.HasOne(d => d.DeliveryMethod)
                .WithMany(p => p.Deliveries)
                .HasForeignKey(d => d.DeliveryMethodId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Deliverie__Deliv__6EF57B66");

            builder.HasOne(d => d.Sale)
                .WithOne(p => p.Delivery)
                .HasForeignKey<Delivery>(d => d.SaleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Deliverie__SaleI__6FE99F9F");

            builder.HasOne(d => d.Status)
                .WithMany(p => p.Deliveries)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Deliverie__Statu__6383C8BA");
        }
    }
}
