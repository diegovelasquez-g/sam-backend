using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SAM.Domain.Entities;

namespace SAM.Infrastructure.Persistences.Contexts.Configurations
{
    public class PaymentsMethodConfiguration : IEntityTypeConfiguration<PaymentsMethod>
    {
        public void Configure(EntityTypeBuilder<PaymentsMethod> builder)
        {
            builder.HasKey(e => e.PaymentMethodId)
                    .HasName("PK__Payments__DC31C1D38799656D");

            builder.Property(e => e.CreatedDate).HasColumnType("datetime");

            builder.Property(e => e.Method)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.ModifiedDate).HasColumnType("datetime");

            builder.Property(e => e.PaymentDate).HasColumnType("datetime");
        }
    }
}
