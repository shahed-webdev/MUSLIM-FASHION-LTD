using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JqueryDataTables.LoopsIT;
using Microsoft.AspNetCore.Authorization;
using MuslimFashion.BusinessLogic;
using MuslimFashion.Data;
using MuslimFashion.ViewModel;
using Order = JqueryDataTables.LoopsIT.Order;

namespace MuslimFashion.Web.Controllers
{
    [Authorize (Roles = "Admin, Sub-Admin")]
    public class OrderController : Controller
    {
        private readonly IOrderCore _order;
        private readonly IProductCore _product;
        private readonly IBasicSettingCore _basicSetting;
        private readonly ICustomerCore _customer;
        public OrderController(IOrderCore order, IProductCore product, IBasicSettingCore basicSetting, ICustomerCore customer)
        {
            _order = order;
            _product = product;
            _basicSetting = basicSetting;
            _customer = customer;
        }
       
        //all order data-table
        public IActionResult OrderData(DataRequest result, OrderStatus status)
        {
            var response = _order.StatusWiseRecords(result,status);
            return Json(response);
        }

        #region Create Order
        public IActionResult CreateOrder()
        {
            ViewBag.DeliveryCost = _basicSetting.GetDeliveryCharge().Data;
            return View();
        }
        
        //post order
        [HttpPost]
        public IActionResult PostCreateOrder(OrderAddModel model)
        {
            var response = _order.PleaseOrder(model, true);
            return Json(response);
        }

        //find product
        public async Task<IActionResult> FindProduct(string code)
        {
            var response = await _product.SearchAsync(code);
            return Json(response);
        }

        //Find Customer
        public async Task<IActionResult> FindCustomer(string prefix)
        {
            var response = await _customer.SearchAsync(prefix);
            return Json(response);
        }

        //get Customer Address
        public IActionResult GetCustomerAddress(int customerId)
        {
            var response =  _customer.AddressList(customerId);
            return Json(response);
        }
        #endregion

        #region Pending Order
        //confirmed list
        public IActionResult PendingList()
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

        #region Delivery Order
        //order confirm
        public IActionResult DeliveryOrder(int? id)
        {
            if (!id.HasValue) return RedirectToAction("ConfirmedList");

            var model = _order.OrderReceipt(id.GetValueOrDefault());
            return View(model.Data);
        }

        //confirm
        [HttpPost]
        public IActionResult PostDeliveryOrder(int orderId)
        {
            var response = _order.Delivered(orderId);
            return Json(response);
        }


        //Delivery list
        public IActionResult DeliveredList()
        {
            return View();
        }

        #endregion

        //order receipt
        public IActionResult Receipt(int? id)
        {
            if (!id.HasValue) return RedirectToAction("PendingList");

            var response = _order.OrderReceipt(id.GetValueOrDefault());
            return View(response.Data);
        }
    }
}
