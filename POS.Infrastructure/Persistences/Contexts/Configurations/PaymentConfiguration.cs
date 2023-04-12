using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SAM.Domain.Entities;

namespace SAM.Infrastructure.Persistences.Contexts.Configurations
{
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.HasIndex(e => e.SaleId, "UQ__Payments__1EE3C3FE5CA7BE9E")
                    .IsUnique();

            builder.Property(e => e.PaymentDate).HasColumnType("datetime");

            builder.Property(e => e.TotalPrice).HasColumnType("decimal(19, 4)");

            builder.HasOne(d => d.PaymentMethod)
                .WithMany(p => p.Payments)
                .HasForeignKey(d => d.PaymentMethodId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Payments__Paymen__6D0D32F4");

            builder.HasOne(d => d.Sale)
                .WithOne(p => p.Payment)
                .HasForeignKey<Payment>(d => d.SaleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Payments__SaleId__6C190EBB");

            builder.HasOne(d => d.Status)
                .WithMany(p => p.Payments)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Payments__Status__6E01572D");
        }
    }
}
