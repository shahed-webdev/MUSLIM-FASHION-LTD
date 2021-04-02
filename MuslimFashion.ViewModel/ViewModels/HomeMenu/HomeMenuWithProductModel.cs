using System.Collections.Generic;

namespace MuslimFashion.ViewModel
{
    public class HomeMenuWithProductModel
    {
        public HomeMenuWithProductModel()
        {
            Products = new List<ProductGridViewModel>();
        }
        public int HomeMenuId { get; set; }
        public string HomeMenuName { get; set; }
        public string ImageFileName { get; set; }
        public List<ProductGridViewModel> Products { get; set; }
    }
}