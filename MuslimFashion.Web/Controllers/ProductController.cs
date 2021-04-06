﻿using System;
using JqueryDataTables.LoopsIT;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MuslimFashion.BusinessLogic;
using MuslimFashion.BusinessLogic.Menu;
using MuslimFashion.ViewModel;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using MuslimFashion.Data;

namespace MuslimFashion.Web.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        private readonly IProductCore _product;
        private readonly IMenuCore _menu;
        private readonly ISubMenuCore _subMenu;
        private readonly ISizeCore _size;
        private readonly IHomeMenuCore _homeMenu;

        public ProductController(IMenuCore menu, ISubMenuCore subMenu, ISizeCore size, IProductCore product, IHomeMenuCore homeMenu)
        {
            _menu = menu;
            _subMenu = subMenu;
            _size = size;
            _product = product;
            _homeMenu = homeMenu;
        }

        #region Product List
        public IActionResult AllProducts()
        {
            return View();
        }

        //details
        public IActionResult Details(int? id)
        {
            if (!id.HasValue) return RedirectToAction("AllProducts");
            return View();
        }

        //data table
        public IActionResult GetAllProductData(DataRequest request)
        {
            var response = _product.ListByAdmin(request);
            return Json(response);
        }
        #endregion

        #region Add Product

        //add
        public IActionResult AddProduct()
        {
            ViewBag.Menus = new SelectList(_menu.ListDdl(), "value", "label");
            ViewBag.Sizes = new SelectList(_size.ListDdl(), "value", "label");

            return View();
        }

        //get sub menu
        [HttpPost]
        public IActionResult GetSubMenuByMenu(int id)
        {
            var response = _subMenu.MenuWiseDdlList(id);
            return Json(response);
        }


        public async Task<IActionResult> PostAddProduct(ProductAddModel model, IFormFile imageFile)
        {
            var response = await _product.AddAsync(model, imageFile);
            return Json(response);
        }
        #endregion

        #region Home Page Category
        //get home category
        public IActionResult HomeCategory()
        {
            var response = _homeMenu.List();
            return View(response);
        }

        //Add
        public async Task<IActionResult> PostHomeCategory(HomeMenuCrudModel model, IFormFile file)
        {
            var response = await _homeMenu.AddAsync(model, file);
            return Json(response);
        }


        //Update
        public async Task<IActionResult> UpdateHomeCategory(HomeMenuCrudModel model, IFormFile file)
        {
            var response = await _homeMenu.EditAsync(model,file);
            return Json(response);
        }

        //Delete
        public IActionResult DeleteHomeCategory(int id)
        {
            var response =  _homeMenu.Delete(id);
            return Json(response);
        }



        //assign product
        public IActionResult AssignProductInCategory(int? id)
        {
            if (!id.HasValue) return RedirectToAction("HomeCategory");
            
            return View();
        }

        //data table
        public IActionResult GetUnassignedData(DataRequest request, int id)
        {
            var response = _product.ListOfUnassignedHomeMenu(request, id);
            return Json(response);
        }

        //post assign
        public IActionResult PostAssignCategory(HomeMenuAddProductModel model)
        {
            var response = _homeMenu.AddProduct(model);
            return Json(response);
        }
        #endregion

        #region Add to cart and order

        //add to cart
        [AllowAnonymous]
        public IActionResult Item(int? id)
        {
            if (!id.HasValue) return RedirectToAction("index", "home");
           
            var model = _product.Get(id.GetValueOrDefault());
            return View(model.Data);
        }

        //Checkout
        [AllowAnonymous]
        public IActionResult Checkout()
        {
            if (!User.Identity.IsAuthenticated)
                return Redirect("/Account/Login/?returnUrl=/Product/Checkout");

            if (!User.IsInRole("Customer"))
                return Redirect("/Home/Index");


            //ViewBag.DeliveryCost = new SelectList(_region.ListDdl(), "value", "label");
            //var response = _customer.AddressList(User.Identity.Name);

            return View();
        }


        //Post Shipping Address (Authorize(Roles = "Customer")
        //[Authorize(Roles = "Customer")]
        //[HttpPost]
        //public IActionResult PostShippingAddress(CustomerAddress model)
        //{
        //    var response = _customer.AddressAdd(model, User.Identity.Name);
        //    return Json(response);
        //}

        //place order
        //[Authorize(Roles = "Customer")]
        //[HttpPost]
        //public IActionResult PlaceOrder(OrderPlaceModel model)
        //{
        //    var response = _order.OrderPlace(model, User.Identity.Name);
        //    return Json(response);
        //}

        #endregion
    }
}
