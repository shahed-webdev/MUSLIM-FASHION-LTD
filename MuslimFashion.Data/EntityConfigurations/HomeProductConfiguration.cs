using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MuslimFashion.Data
{
    public class HomeProductConfiguration : IEntityTypeConfiguration<HomeProduct>
    {
        public void Configure(EntityTypeBuilder<HomeProduct> builder)
        {
            builder.HasOne(e => e.Product)
                .WithMany(e => e.HomeProducts)
                .HasForeignKey(e => e.ProductId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_HomeProduct_Product");

            builder.HasOne(e => e.HomeMenu)
                .WithMany(e => e.HomeProducts)
                .HasForeignKey(e => e.HomeMenuId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_HomeProduct_HomeMenu");
        }
    }
}