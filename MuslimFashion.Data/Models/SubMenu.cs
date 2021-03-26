using System;
using System.Collections.Generic;

namespace MuslimFashion.Data
{
    public class SubMenu
    {
        public SubMenu()
        {
            Products = new HashSet<Product>();
        }
        public int SubMenuId { get; set; }
        public int MenuId { get; set; }
        public string SubMenuName { get; set; }
        public DateTime InsertDateUtc { get; set; }
        public Menu Menu { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}