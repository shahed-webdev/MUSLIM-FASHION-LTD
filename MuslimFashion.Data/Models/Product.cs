using System;

namespace MuslimFashion.Data
{
    public class Product
    {
        public int ProductId { get; set; }
        public int SubMenuId { get; set; }
        public SubMenu SubMenu { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public decimal OldPrice { get; set; }
        public string ProductCode { get; set; }
        public string Brand { get; set; }
        public string FabricType { get; set; }
        public string Description { get; set; }
        public DateTime InsertDateUtc { get; set; }
    }
}