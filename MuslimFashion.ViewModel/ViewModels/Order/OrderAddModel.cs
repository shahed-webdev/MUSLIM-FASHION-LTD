using System;
using System.Collections.Generic;

namespace MuslimFashion.ViewModel
{
    public class OrderAddModel
    {
        public decimal TotalPrice { get; set; }
        public decimal Discount { get; set; }
        public decimal DeliveryCost { get; set; }
        public bool IsInDhaka { get; set; }
        public int? CustomerId { get; set; }
        public DateTime? OrderDate { get; set; }
        public List<OrderListAddModel> OrderLists { get; set; }
        public string DeliveryName { get; set; }
        public string DeliveryAddress { get; set; }
        public string DeliveryPhone { get; set; }
    }

    public class OrderListAddModel
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public int ProductSizeId { get; set; }
    }
}