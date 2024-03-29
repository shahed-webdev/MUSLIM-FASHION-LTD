﻿using System.Collections.Generic;

namespace MuslimFashion.ViewModel
{
    public class ProductDetailsModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public decimal OldPrice { get; set; }
        public string ProductCode { get; set; }
        public string Brand { get; set; }
        public string FabricType { get; set; }
        public string Description { get; set; }
        public string ImageFileName { get; set; }
        public List<ProductSizeDetailsModel> ProductSizes { get; set; }
        public int SubMenuId { get; set; }
        public string SubMenuName { get; set; }
        public int MenuId { get; set; }
        public string MenuName { get; set; }
    }

    public class ProductSizeDetailsModel
    {
        public int SizeId { get; set; }
        public string SizeName { get; set; }
        public string Description { get; set; }
    }
}