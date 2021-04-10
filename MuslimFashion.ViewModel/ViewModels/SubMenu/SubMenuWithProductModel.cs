using System.Collections.Generic;

namespace MuslimFashion.ViewModel
{
    public class SubMenuWithProductModel
    {
        public SubMenuWithProductModel()
        {
            Products = new List<ProductGridViewModel>();
        }
        public int SubMenuId { get; set; }
        public int MenuId { get; set; }
        public string MenuName { get; set; }
        public string SubMenuName { get; set; }
        public List<ProductGridViewModel> Products { get; set; }
    }
}