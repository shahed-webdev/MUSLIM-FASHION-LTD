using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MuslimFashion.BusinessLogic;
using MuslimFashion.BusinessLogic.Menu;
using MuslimFashion.ViewModel;

namespace MuslimFashion.Web.Controllers
{
    public class BasicSettingsController : Controller
    {
        private readonly IMenuCore _menu;
        private readonly ISubMenuCore _subMenu;
        private readonly IColorCore _color;
        public BasicSettingsController(IMenuCore menu, ISubMenuCore subMenu, IColorCore color)
        {
            _menu = menu;
            _subMenu = subMenu;
            _color = color;
        }

        public IActionResult ImageSlider()
        {
            return View();
        }

        #region Menu
        public IActionResult Menu()
        {
           var mode= _menu.List();
            return View(mode);
        }

        //add
        [HttpPost]
        public IActionResult PostMenu(MenuCrudModel model)
        {
            var response = _menu.Add(model);
            return Json(response);
        }

        //update
        [HttpPost]
        public IActionResult UpdateMenu(MenuCrudModel model)
        {
            var response = _menu.Edit(model);
            return Json(response);
        }

        //delete
        [HttpPost]
        public IActionResult DeleteMenu(int id)
        {
            var response = _menu.Delete(id);
            return Json(response);
        }
        #endregion

        #region Sub Menu
        public IActionResult SubMenu()
        {
            ViewBag.Menus = new SelectList(_menu.ListDdl(), "value", "label");
            return View();
        }

        //get sub-menu list
        public IActionResult GetSubMenu(int id)
        {
            var mode = _subMenu.MenuWiseList(id);
            return Json(mode);
        }

        //add
        [HttpPost]
        public IActionResult PostSubMenu(SubMenuAddEditModel model)
        {
            var response = _subMenu.Add(model);
            return Json(response);
        }

        //update
        [HttpPost]
        public IActionResult UpdateSubMenu(SubMenuAddEditModel model)
        {
            var response = _subMenu.Edit(model);
            return Json(response);
        }

        //delete
        [HttpPost]
        public IActionResult DeleteSubMenu(int id)
        {
            var response = _subMenu.Delete(id);
            return Json(response);
        }
        #endregion

        #region Colors
        public IActionResult Colors()
        {
            return View(_color.List());
        }

        //add
        [HttpPost]
        public IActionResult PostColor(ColorCrudModel model)
        {
            var response = _color.Add(model);
            return Json(response);
        }

        //update
        [HttpPost]
        public IActionResult UpdateColor(ColorCrudModel model)
        {
            var response = _color.Edit(model);
            return Json(response);
        }

        //delete
        [HttpPost]
        public IActionResult DeleteColor(int id)
        {
            var response = _color.Delete(id);
            return Json(response);
        }
        #endregion
    }
}
