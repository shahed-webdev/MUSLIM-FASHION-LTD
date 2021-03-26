using System;
using System.Collections.Generic;

namespace MuslimFashion.Data
{
    public class Size
    {
        public Size()
        {
            ProductSizes = new HashSet<ProductSize>();
        }
        public int SizeId { get; set; }
        public string SizeName { get; set; }
        public string Description { get; set; }
        public DateTime InsertDateUtc { get; set; }
        public ICollection<ProductSize> ProductSizes { get; set; }
    }
}