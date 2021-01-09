using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
