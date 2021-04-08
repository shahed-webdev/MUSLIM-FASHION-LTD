using System.Collections.Generic;

namespace MuslimFashion.ViewModel
{
    public class ProductFindViewModel
    {
        public ProductFindViewModel()
        {
            Sizes = new List<ProductFindSizeModel>();
        }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string ProductCode { get; set; }
        public string Brand { get; set; }
        public string ImageFileName { get; set; }

        public List<ProductFindSizeModel> Sizes { get; set; }
    }

    public class ProductFindSizeModel
    {
        public int ProductSizeId { get; set; }
        public string SizeName { get; set; }
    }
}