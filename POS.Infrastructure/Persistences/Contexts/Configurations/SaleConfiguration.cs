using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SAM.Domain.Entities;

namespace SAM.Infrastructure.Persistences.Contexts.Configurations
{
    public class SaleConfiguration : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.Property(e => e.SaleCode)
                    .HasMaxLength(20)
                    .IsUnicode(false);

            builder.Property(e => e.SaleDate).HasColumnType("datetime");

            builder.HasOne(d => d.User)
                .WithMany(p => p.Sales)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Sales__UserId__693CA210");
        }
    }
}
