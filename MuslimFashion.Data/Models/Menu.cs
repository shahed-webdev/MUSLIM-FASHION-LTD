using System;
using System.Collections.Generic;

namespace MuslimFashion.Data
{
    public class Menu
    {
        public Menu()
        {
            SubMenus = new HashSet<SubMenu>();
        }

        public int MenuId { get; set; }
        public string MenuName { get; set; }
        public DateTime InsertDateUtc { get; set; }
        public ICollection<SubMenu> SubMenus { get; set; }
    }
}