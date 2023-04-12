using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SAM.Domain.Entities;

namespace SAM.Infrastructure.Persistences.Contexts.Configurations
{
    public class DeliveriesMethodConfiguration : IEntityTypeConfiguration<DeliveriesMethod>
    {
        public void Configure(EntityTypeBuilder<DeliveriesMethod> builder)
        {
            builder.HasKey(e => e.DeliveryMethodId)
                    .HasName("PK__Deliveri__7B03A0420037F82D");

            builder.Property(e => e.CreatedDate).HasColumnType("datetime");

            builder.Property(e => e.Method)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.ModifiedDate).HasColumnType("datetime");
        }
    }
}
