using System;
using System.Collections.Generic;

namespace MuslimFashion.Data
{
    public class Color
    {
        public Color()
        {
            ProductColors = new HashSet<ProductColor>();
        }
        public int ColorId { get; set; }
        public string ColorName { get; set; }
        public string ColorCode { get; set; }
        public DateTime InsertDateUtc { get; set; }
        public ICollection<ProductColor> ProductColors { get; set; }
    }
}