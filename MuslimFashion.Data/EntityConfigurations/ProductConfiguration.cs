using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MuslimFashion.Data
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(e => e.ProductName)
                .IsRequired()
                .HasMaxLength(256);
            builder.Property(e => e.Brand)
                .HasMaxLength(128);
            builder.Property(e => e.FabricType)
                .HasMaxLength(128);
            builder.Property(e => e.ProductCode)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(e => e.Description)
                .HasMaxLength(1024);
            builder.Property(e => e.ImageFileName)
                .HasMaxLength(128);
            builder.Property(e => e.Price)
                .HasColumnType("decimal(18, 2)");
            builder.Property(e => e.OldPrice)
                .HasColumnType("decimal(18, 2)");
            builder.Property(e => e.InsertDateUtc)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getutcdate())");
            builder.HasOne(e => e.SubMenu)
                .WithMany(e => e.Products)
                .HasForeignKey(e => e.SubMenuId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_Product_SubMenu");

        }
    }
}