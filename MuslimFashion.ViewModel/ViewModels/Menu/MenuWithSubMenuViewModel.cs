using System.Collections.Generic;

namespace MuslimFashion.ViewModel
{
    public class MenuWithSubMenuViewModel
    {
        public MenuWithSubMenuViewModel()
        {
            SubMenus = new List<SubMenuViewModel>();
        }
        public int MenuId { get; set; }
        public string MenuName { get; set; }
        public List<SubMenuViewModel> SubMenus { get; set; }
    }
}