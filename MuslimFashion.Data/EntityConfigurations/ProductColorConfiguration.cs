using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MuslimFashion.Data
{
    public class ProductColorConfiguration : IEntityTypeConfiguration<ProductColor>
    {
        public void Configure(EntityTypeBuilder<ProductColor> builder)
        {
            builder.HasOne(e => e.Product)
                .WithMany(e => e.ProductColors)
                .HasForeignKey(e => e.ProductId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_ProductColor_Product");

            builder.HasOne(e => e.Color)
                .WithMany(e => e.ProductColors)
                .HasForeignKey(e => e.ColorId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_ProductColor_Color");
        }
    }
}