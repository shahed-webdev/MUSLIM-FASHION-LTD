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
        public HomeController(IHomeMenuCore homeMenu)
        {
            _homeMenu = homeMenu;
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
