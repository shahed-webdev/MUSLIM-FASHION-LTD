using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using MuslimFashion.BusinessLogic;
using MuslimFashion.BusinessLogic.Menu;
using MuslimFashion.ViewModel;

namespace MuslimFashion.Web.Controllers
{
    public class ProductController : Controller
    {
       // private readonly IProductCore _product;
        private readonly IMenuCore _menu;
        private readonly ISubMenuCore _subMenu;
        private readonly IColorCore _color;
        private readonly ISizeCore _size;

        public ProductController( IMenuCore menu, ISubMenuCore subMenu, IColorCore color, ISizeCore size)
        {
            //_product = product;
            _menu = menu;
            _subMenu = subMenu;
            _color = color;
            _size = size;
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
            return View();
        }

        //public IActionResult PostAddProduct(ProductAddModel model)
        //{
        //    var response = _product.Add(model);
        //    return Json(response);
        //}
        #endregion
    }
}
