using JqueryDataTables.LoopsIT;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MuslimFashion.BusinessLogic;
using MuslimFashion.BusinessLogic.Menu;
using MuslimFashion.ViewModel;
using System.Threading.Tasks;

namespace MuslimFashion.Web.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        private readonly IProductCore _product;
        private readonly IMenuCore _menu;
        private readonly ISubMenuCore _subMenu;
        private readonly ISizeCore _size;

        public ProductController(IMenuCore menu, ISubMenuCore subMenu, ISizeCore size, IProductCore product)
        {
            //_product = product;
            _menu = menu;
            _subMenu = subMenu;
            _size = size;
            _product = product;
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
        //add home category
        public IActionResult HomeCategory()
        {
            return View();
        }

        //assign product
        public IActionResult AssignProductInCategory(int? id)
        {
            if (!id.HasValue) return RedirectToAction("HomeCategory");
            return View();
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
