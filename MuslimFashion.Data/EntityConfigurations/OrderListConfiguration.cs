using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MuslimFashion.Data
{
    public class OrderListConfiguration : IEntityTypeConfiguration<OrderList>
    {
        public void Configure(EntityTypeBuilder<OrderList> builder)
        {
            builder.Property(e => e.UnitPrice)
                .HasColumnType("decimal(18, 2)");
            builder.Property(e => e.ProductSize)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(e => e.LineTotal)
                .HasComputedColumnSql("([UnitPrice] * [Quantity])");
            builder.HasOne(e => e.Product)
                .WithMany(o => o.OrderLists)
                .HasForeignKey(e => e.ProductId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_OrderList_Product");

            builder.HasOne(e => e.Order)
                .WithMany(o => o.OrderLists)
                .HasForeignKey(e => e.OrderId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_OrderList_Order");
        }
    }
}