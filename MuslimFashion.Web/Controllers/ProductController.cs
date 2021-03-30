using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc.Rendering;
using MuslimFashion.BusinessLogic;
using MuslimFashion.BusinessLogic.Menu;
using MuslimFashion.ViewModel;

namespace MuslimFashion.Web.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        private readonly IProductCore _product;
        private readonly IMenuCore _menu;
        private readonly ISubMenuCore _subMenu;
        private readonly IColorCore _color;
        private readonly ISizeCore _size;

        public ProductController( IMenuCore menu, ISubMenuCore subMenu, IColorCore color, ISizeCore size, IProductCore product)
        {
            //_product = product;
            _menu = menu;
            _subMenu = subMenu;
            _color = color;
            _size = size;
            _product = product;
        }
        
        public IActionResult AllProducts()
        {
            return View();
        }


        #region Add Product
        //add
        public IActionResult AddProduct()
        {
            ViewBag.Menus = new SelectList(_menu.ListDdl(), "value", "label");
            ViewBag.Colors = new SelectList(_color.ListDdl(), "value", "label");
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


        public IActionResult PostAddProduct(ProductAddModel model, IFormFile[] productImageFiles)
        {
            var response = _product.Add(model);
            return Json(response);
        }
        #endregion

        #region Add to cart and order
        //add to cart
        [AllowAnonymous]
        public IActionResult Item(int? id)
        {
            if (!id.HasValue) return RedirectToAction("index", "home");
            return View();
        }


        #endregion
    }
}
