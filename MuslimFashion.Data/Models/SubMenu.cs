using System;

namespace MuslimFashion.Data
{
    public class SubMenu
    {
        public int SubMenuId { get; set; }
        public int MenuId { get; set; }
        public string SubMenuName { get; set; }
        public DateTime InsertDateUtc { get; set; }
        public Menu Menu { get; set; }
    }
}