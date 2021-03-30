namespace MuslimFashion.ViewModel
{
    public class ProductAddModel
    {
        public int SubMenuId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public decimal OldPrice { get; set; }
        public string ProductCode { get; set; }
        public string Brand { get; set; }
        public string FabricType { get; set; }
        public string Description { get; set; }
        public string ImageFileName { get; set; }
        public int[] ProductColors { get; set; }
        public int[] ProductSizes { get; set; }
    }
}