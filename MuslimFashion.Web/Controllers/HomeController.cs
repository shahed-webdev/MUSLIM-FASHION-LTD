using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MuslimFashion.BusinessLogic;

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
            var model = _homeMenu.ListWithProducts();
            return View(model);
        }

        public IActionResult Contact()
        {
            return View();
        }
    }
}
