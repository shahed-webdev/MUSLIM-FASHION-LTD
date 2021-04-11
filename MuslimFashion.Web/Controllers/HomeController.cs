using Microsoft.AspNetCore.Mvc;
using MuslimFashion.BusinessLogic;
using MuslimFashion.ViewModel;

namespace MuslimFashion.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHomeMenuCore _homeMenu;
        private readonly ISliderCore _slider;
        public HomeController(IHomeMenuCore homeMenu, ISliderCore slider)
        {
            _homeMenu = homeMenu;
            _slider = slider;
        }

        public IActionResult Index()
        {
            var model = new HomeViewModel
            {
                MenuWithProducts = _homeMenu.ListWithProducts(),
                Slider = _slider.Slide()
            };

            return View(model);
        }

        public IActionResult Contact()
        {
            return View();
        }
    }
}
