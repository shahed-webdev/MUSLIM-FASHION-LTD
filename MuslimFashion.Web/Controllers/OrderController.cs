using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MuslimFashion.Web.Controllers
{
    public class OrderController : Controller
    {
        public OrderController()
        {
            
        }

        #region Create Order
        public IActionResult CreateOrder()
        {
            return View();
        }
        #endregion
       
    }
}
