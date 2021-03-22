using Microsoft.AspNetCore.Mvc;

namespace MuslimFashion.Web.Controllers
{
    public class BasicSettingsController : Controller
    {
        public IActionResult ImageSlider()
        {
            return View();
        }

        //brand
        public IActionResult Brands()
        {
            return View();
        }
    }
}
