namespace MuslimFashion.Data
{
    public class ProductSize
    {
        public int ProductSizeId { get; set; }
        public int ProductId { get; set; }
        public int SizeId { get; set; }
        public Size Size { get; set; }
        public Product Product { get; set; }
    }
}