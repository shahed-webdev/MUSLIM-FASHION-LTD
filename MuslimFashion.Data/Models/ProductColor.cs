namespace MuslimFashion.Data
{
    public class ProductColor
    {
        public int ProductColorId { get; set; }
        public int ProductId { get; set; }
        public int ColorId { get; set; }
        public Color Color { get; set; }
        public Product Product { get; set; }
    }
}