namespace MuslimFashion.Data
{
    public class HomeProduct
    {
        public int HomeProductId { get; set; }
        public int ProductId { get; set; }
        public int HomeMenuId { get; set; }
        public HomeMenu HomeMenu { get; set; }
        public Product Product { get; set; }
    }
}