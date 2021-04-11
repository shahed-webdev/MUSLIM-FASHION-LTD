using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MuslimFashion.BusinessLogic;
using MuslimFashion.BusinessLogic.Menu;
using MuslimFashion.ViewModel;

namespace MuslimFashion.Web.Controllers
{
    [Authorize]
    public class BasicSettingsController : Controller
    {
        private readonly ISliderCore _slider;
        private readonly IBasicSettingCore _basicSetting;
        private readonly IMenuCore _menu;
        private readonly ISubMenuCore _subMenu;
        private readonly ISizeCore _size;
        public BasicSettingsController(IMenuCore menu, ISubMenuCore subMenu, ISizeCore size, IBasicSettingCore basicSetting, ISliderCore slider)
        {
            _menu = menu;
            _subMenu = subMenu;
            _size = size;
            _basicSetting = basicSetting;
            _slider = slider;
        }

        #region Image slider
        public IActionResult ImageSlider()
        {
            var model = _slider.List();
            return View(model);
        }

        //post
        public async Task<IActionResult> PostImageSlider(SliderCrudModel model, IFormFile imageFile)
        {
            var response = await _slider.AddAsync(model, imageFile);
            return Json(response);
        }

        //delete
        public IActionResult DeleteImageSlider(int id)
        {
            var response = _slider.Delete(id);
            return Json(response);
        }

        #endregion


        #region Menu
        public IActionResult Menu()
        {
            var mode = _menu.List();
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


        //get menus from layout
        [AllowAnonymous]
        public IActionResult RenderMenu()
        {
            var model = _menu.ListWithSubMenu();
            return Json(model);
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

        #region Size
        public IActionResult Size()
        {
            return View(_size.List());
        }

        //add
        [HttpPost]
        public IActionResult PostSize(SizeCrudModel model)
        {
            var response = _size.Add(model);
            return Json(response);
        }

        //update
        [HttpPost]
        public IActionResult UpdateSize(SizeCrudModel model)
        {
            var response = _size.Edit(model);
            return Json(response);
        }

        //delete
        [HttpPost]
        public IActionResult DeleteSize(int id)
        {
            var response = _size.Delete(id);
            return Json(response);
        }
        #endregion

        #region Delivery Cost
        public IActionResult DeliveryCost()
        {
            var model = _basicSetting.GetDeliveryCharge();
            return View(model.Data);
        }


        //update
        [HttpPost]
        public IActionResult DeliveryCost(DeliveryChargeModel model)
        {
             _basicSetting.ChangeDeliveryCharge(model);
            return View(model);
        }


        #endregion
    }
}
