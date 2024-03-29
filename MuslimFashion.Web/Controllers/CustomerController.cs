﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JqueryDataTables.LoopsIT;
using Microsoft.AspNetCore.Authorization;
using MuslimFashion.BusinessLogic;
using MuslimFashion.ViewModel;

namespace MuslimFashion.Web.Controllers
{
    [Authorize(Roles = "Customer")]
    public class CustomerController : Controller
    {
        private readonly ICustomerCore _customer;
        private readonly IOrderCore _order;
        public CustomerController(ICustomerCore customer, IOrderCore order)
        {
            _customer = customer;
            _order = order;
        }
        public IActionResult Dashboard()
        {
            return View();
        }

        //address book
        public IActionResult AddressBook()
        {
            var response = _customer.AddressList(User.Identity.Name);
            return View(response);
        }

        //Update Shipping address
        [HttpPost]
        public IActionResult UpdateShippingAddress(CustomerAddressCrudModel model)
        {
            var response = _customer.EditAddress(model);
            return Json(response);
        }

        //Payment Method
        public IActionResult PaymentMethod()
        {
            return View();
        }


        #region Order
        //all order
        public IActionResult MyOrderData(DataRequest result)
        {
            var response = _order.CustomerWiseRecords(result, User.Identity.Name);
            return Json(response);
        }

        //Order Details
        public IActionResult OrderDetails(int? id)
        {
            if (!id.HasValue) return RedirectToAction("Dashboard");

            var response = _order.OrderReceipt(id.GetValueOrDefault());
            return View(response.Data);
        }
        #endregion
    }
}
