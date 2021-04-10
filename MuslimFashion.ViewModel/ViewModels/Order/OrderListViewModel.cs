using System;

namespace MuslimFashion.ViewModel
{
    public class OrderListViewModel
    {
        public int OrderId { get; set; }
        public int? CustomerId { get; set; }
        public int OrderNo { get; set; }
        public string OrderStatus { get; set; }
        public decimal NetAmount { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime? StatusChangeDate { get; set; }
        public string DeliveryName { get; set; }
        public string DeliveryAddress { get; set; }
        public string DeliveryPhone { get; set; }
    }
}