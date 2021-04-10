using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JqueryDataTables.LoopsIT;
using MuslimFashion.BusinessLogic;

namespace MuslimFashion.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderCore _order;
        public OrderController(IOrderCore order)
        {
            _order = order;
        }
        //order data-table
        public IActionResult OrderData(DataRequest result)
        {
            var response = _order.Records(result);
            return Json(response);
        }


        #region Create Order
        public IActionResult CreateOrder()
        {
            return View();
        }
        #endregion
       
    }
}
