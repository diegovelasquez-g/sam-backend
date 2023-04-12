using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SAM.Domain.Entities;

namespace SAM.Infrastructure.Persistences.Contexts.Configurations
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.Property(e => e.AddressLine1).IsUnicode(false);

            builder.Property(e => e.Department)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Municipality)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.HasOne(d => d.User)
                .WithMany(p => p.Addresses)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Addresses__UserI__5DCAEF64");
        }
    }
}
