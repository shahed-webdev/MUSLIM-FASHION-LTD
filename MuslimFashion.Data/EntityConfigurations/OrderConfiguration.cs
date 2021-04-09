using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace MuslimFashion.Data
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(e => e.DeliveryAddress)
                .IsRequired()
                .HasMaxLength(1024);
            builder.Property(e => e.DeliveryPhone)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(e => e.DeliveryName)
                .IsRequired()
                .HasMaxLength(128);
            builder.Property(e => e.OrderStatus)
                .HasMaxLength(50)
                .HasConversion(c => c.ToString(), c => Enum.Parse<OrderStatus>(c));
            builder.Property(e => e.DeliveryCost)
                .HasColumnType("decimal(18, 2)");
            builder.Property(e => e.TotalPrice)
                .HasColumnType("decimal(18, 2)");
            builder.Property(e => e.Discount)
                .HasColumnType("decimal(18, 2)");
            builder.Property(e => e.NetAmount)
                .HasComputedColumnSql("(([TotalPrice]-[Discount])+[DeliveryCost])");
            builder.Property(e => e.InsertDateUtc)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getutcdate())");
            builder.Property(e => e.OrderDate)
                .HasColumnType("datetime");
            builder.Property(e => e.StatusChangeDate)
                .HasColumnType("datetime");
        }
    }
}