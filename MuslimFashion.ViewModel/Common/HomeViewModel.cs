using System.Collections.Generic;

namespace MuslimFashion.ViewModel
{
    public class HomeViewModel
    {
        public HomeViewModel()
        {
            MenuWithProducts = new List<HomeMenuWithProductModel>();
            Slider = new List<SliderSlideModel>();
        }
        public List<HomeMenuWithProductModel> MenuWithProducts { get; set; }
        public List<SliderSlideModel> Slider { get; set; }

    }
}