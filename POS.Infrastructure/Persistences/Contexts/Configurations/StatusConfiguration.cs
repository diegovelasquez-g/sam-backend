using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SAM.Domain.Entities;

namespace SAM.Infrastructure.Persistences.Contexts.Configurations
{
    public class StatusConfiguration : IEntityTypeConfiguration<Status>
    {
        public void Configure(EntityTypeBuilder<Status> builder)
        {
            builder.ToTable("Status");

            builder.Property(e => e.CreatedDate).HasColumnType("datetime");

            builder.Property(e => e.Description)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("description");

            builder.Property(e => e.StatusName)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.StatusType)
                .HasMaxLength(20)
                .IsUnicode(false);
        }
    }
}
