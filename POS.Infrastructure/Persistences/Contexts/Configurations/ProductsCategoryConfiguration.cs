using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SAM.Domain.Entities;

namespace SAM.Infrastructure.Persistences.Contexts.Configurations
{
    public class ProductsCategoryConfiguration : IEntityTypeConfiguration<ProductsCategory>
    {
        public void Configure(EntityTypeBuilder<ProductsCategory> builder)
        {
            builder.ToTable("Products_Categories");

            builder.HasOne(d => d.Category)
                .WithMany(p => p.ProductsCategories)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Products___Categ__619B8048");

            builder.HasOne(d => d.Product)
                .WithMany(p => p.ProductsCategories)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Products___Produ__60A75C0F");
        }
    }
}
