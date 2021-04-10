using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JqueryDataTables.LoopsIT;
using MuslimFashion.BusinessLogic;
using MuslimFashion.Data;

namespace MuslimFashion.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderCore _order;
        public OrderController(IOrderCore order)
        {
            _order = order;
        }
       
        //all order data-table
        public IActionResult OrderData(DataRequest result, OrderStatus status)
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

        #region Confirm Order
        //order confirm
        public IActionResult ConfirmOrder(int? id)
        {
            if (!id.HasValue) return RedirectToAction("Index", "Dashboard");

            var model = _order.OrderReceipt(id.GetValueOrDefault());
            return View(model.Data);
        }
        
        //confirm
        [HttpPost]
        public IActionResult PostConfirmOrder(int orderId, decimal discount)
        {
            var response = _order.Confirmed(orderId, discount);
            return Json(response);
        }

        //reject
        [HttpPost]
        public IActionResult PostRejectOrder(int orderId)
        {
            var response = _order.Delete(orderId);
            return Json(response);
        }

        //confirmed list
        public IActionResult ConfirmedList()
        {
            return View();
        }

        #endregion

    }
}
