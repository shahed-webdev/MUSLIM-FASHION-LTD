using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MuslimFashion.Data
{
    public class ProductSizeConfiguration : IEntityTypeConfiguration<ProductSize>
    {
        public void Configure(EntityTypeBuilder<ProductSize> builder)
        {
            builder.HasOne(e => e.Product)
                .WithMany(e => e.ProductSizes)
                .HasForeignKey(e => e.ProductId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_ProductSize_Product");

            builder.HasOne(e => e.Size)
                .WithMany(e => e.ProductSizes)
                .HasForeignKey(e => e.SizeId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_ProductSize_Size");
        }
    }
}