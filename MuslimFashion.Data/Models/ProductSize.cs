using System.Collections.Generic;

namespace MuslimFashion.Data
{
    public class ProductSize
    {
        public ProductSize()
        {
            OrderLists = new HashSet<OrderList>();
        }
        public int ProductSizeId { get; set; }
        public int ProductId { get; set; }
        public int SizeId { get; set; }
        public Size Size { get; set; }
        public Product Product { get; set; }
        public ICollection<OrderList> OrderLists { get; set; }
    }
}