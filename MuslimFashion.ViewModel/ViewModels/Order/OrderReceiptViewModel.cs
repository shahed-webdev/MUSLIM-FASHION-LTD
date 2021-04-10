using MuslimFashion.Data;
using System;
using System.Collections.Generic;

namespace MuslimFashion.ViewModel
{
    public class OrderReceiptViewModel
    {
        public int OrderId { get; set; }
        public int? CustomerId { get; set; }
        public int OrderNo { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public decimal NetAmount { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime StatusChangeDate { get; set; }
        public string DeliveryName { get; set; }
        public string DeliveryAddress { get; set; }
        public string DeliveryPhone { get; set; }
        public List<OrderReceiptItemModel> OrderLists { get; set; }
    }

    public class OrderReceiptItemModel
    {
        public int OrderListId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal LineTotal { get; set; }
        public int ProductSizeId { get; set; }
        public string SizeName { get; set; }
        public string Description { get; set; }
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public string Brand { get; set; }
        public string FabricType { get; set; }
        public string ImageFileName { get; set; }
    }
}