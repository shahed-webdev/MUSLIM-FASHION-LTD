using System.Collections.Generic;

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
        public string[] ImageFileNames { get; set; }
        public Dictionary<int, string> ProductColors { get; set; }
        public Dictionary<int, string> ProductSizes { get; set; }
    }
}