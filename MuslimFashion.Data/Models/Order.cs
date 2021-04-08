﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace MuslimFashion.Data
{
    public class Order
    {
        public Order()
        {
            OrderLists = new HashSet<OrderList>();
        }
        public int OrderId { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal Discount { get; set; }
        public decimal DeliveryCost { get; set; }
        public bool IsInDhaka { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public decimal NetAmount { get; set; }
        public Customer Customer { get; set; }
        public int? CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime StatusChangeDate { get; set; }
        public DateTime InsertDateUtc { get; set; }
        public ICollection<OrderList> OrderLists { get; set; }
        public string DeliveryName { get; set; }
        public string DeliveryAddress { get; set; }
        public string DeliveryPhone { get; set; }
    }
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
            builder.Property(e => e.DeliveryCost)
                .HasColumnType("decimal(18, 2)");
            builder.Property(e => e.TotalPrice)
                .HasColumnType("decimal(18, 2)");
            builder.Property(e => e.Discount)
                .HasColumnType("decimal(18, 2)");
            builder.Property(e => e.NetAmount)
                .HasComputedColumnSql("(([TotalPrice]-[Discount])+[DeliveryCost])");
        }
    }
}