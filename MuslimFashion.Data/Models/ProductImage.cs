namespace MuslimFashion.Data
{
    public class ProductImage
    {
        public int ProductImageId { get; set; }
        public int ProductId { get; set; }
        public string ImageFileName { get; set; }
        public Product Product { get; set; }

    }
}