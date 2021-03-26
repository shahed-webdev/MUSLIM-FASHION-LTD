using System;
using System.Collections.Generic;

namespace MuslimFashion.Data
{
    public class HomeMenu
    {
        public HomeMenu()
        {
            HomeProducts = new HashSet<HomeProduct>();
        }
        public int HomeMenuId { get; set; }
        public string HomeMenuName { get; set; }
        public string ImageFileName { get; set; }
        public DateTime InsertDateUtc { get; set; }
        public ICollection<HomeProduct> HomeProducts { get; set; }
    }
}