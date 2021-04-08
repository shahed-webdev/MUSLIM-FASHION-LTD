using System;
using System.Collections.Generic;

namespace MuslimFashion.Data
{
    public class Product
    {
        public Product()
        {
            ProductSizes = new HashSet<ProductSize>();
            HomeProducts = new HashSet<HomeProduct>();
            OrderLists = new HashSet<OrderList>();
        }
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
        public string ImageFileName { get; set; }
        public DateTime InsertDateUtc { get; set; }
        public ICollection<ProductSize> ProductSizes { get; set; }
        public ICollection<HomeProduct> HomeProducts { get; set; }
        public ICollection<OrderList> OrderLists { get; set; }

    }
}