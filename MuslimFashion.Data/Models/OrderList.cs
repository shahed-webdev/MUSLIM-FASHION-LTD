namespace MuslimFashion.Data
{
    public class OrderList
    {
        public int OrderListId { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal LineTotal { get; set; }
        public string ProductSize { get; set; }
    }
}