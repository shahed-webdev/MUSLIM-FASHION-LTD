using AutoMapper;
using AutoMapper.QueryableExtensions;
using MuslimFashion.Data;
using MuslimFashion.ViewModel;
using System.Collections.Generic;
using System.Linq;

namespace MuslimFashion.Repository
{
    public class SubMenuRepository : Repository, ISubMenuRepository
    {
        public SubMenuRepository(ApplicationDbContext db, IMapper mapper) : base(db, mapper)
        {
        }

        public DbResponse<SubMenuAddEditModel> Add(SubMenuAddEditModel model)
        {
            var subMenu = _mapper.Map<SubMenu>(model);
            Db.SubMenu.Add(subMenu);
            Db.SaveChanges();
            model.SubMenuId = subMenu.SubMenuId;

            return new DbResponse<SubMenuAddEditModel>(true, $"{model.SubMenuName} Added Successfully", model);
        }

        public DbResponse Edit(SubMenuAddEditModel model)
        {
            var subMenu = Db.SubMenu.Find(model.SubMenuId);
            subMenu.SubMenuName = model.SubMenuName;
            subMenu.MenuId = subMenu.MenuId;
            Db.SubMenu.Update(subMenu);
            Db.SaveChanges();
            return new DbResponse(true, $"{subMenu.SubMenuName} Updated Successfully");
        }

        public DbResponse Delete(int id)
        {

            var subMenu = Db.SubMenu.Find(id);
            Db.SubMenu.Remove(subMenu);
            Db.SaveChanges();
            return new DbResponse(true, $"{subMenu.SubMenuName} Deleted Successfully");
        }

        public DbResponse<SubMenuWithMenuModel> Get(int id)
        {
            var subMenu = Db.SubMenu.Where(r => r.MenuId == id)
                .ProjectTo<SubMenuWithMenuModel>(_mapper.ConfigurationProvider)
                .FirstOrDefault();
            return new DbResponse<SubMenuWithMenuModel>(true, $"{subMenu.SubMenuName} Get Successfully", subMenu);
        }

        public bool IsExistName(string name, int menuId)
        {
            return Db.SubMenu.Any(r => r.SubMenuName == name && r.MenuId == menuId);
        }

        public bool IsExistName(string name, int menuId, int updateId)
        {
            return Db.SubMenu.Any(r => r.SubMenuName == name && r.MenuId == menuId && r.SubMenuId != updateId);
        }

        public bool IsNull(int id)
        {
            return !Db.SubMenu.Any(r => r.SubMenuId == id);
        }

        public bool IsRelatedDataExist(int id)
        {
            return false;
        }

        public List<SubMenuViewModel> MenuWiseList(int menuId)
        {
            return Db.SubMenu
                .Where(m => m.MenuId == menuId)
                .ProjectTo<SubMenuViewModel>(_mapper.ConfigurationProvider)
                .OrderBy(a => a.SubMenuName)
                .ToList();
        }

        public List<DDL> MenuWiseDdlList(int menuId)
        {
            return Db.SubMenu
                .Where(m => m.MenuId == menuId)
                .OrderBy(a => a.SubMenuName)
                .Select(m => new DDL
                {
                    value = m.SubMenuId.ToString(),
                    label = m.SubMenuName
                }).ToList();
        }
        public DbResponse<SubMenuWithProductModel> GetWithProducts(int id)
        {
            var menu = Db.SubMenu.Where(r => r.SubMenuId == id)
                .ProjectTo<SubMenuWithProductModel>(_mapper.ConfigurationProvider)
                .FirstOrDefault();
            menu.Products = Products(menu.SubMenuId, 0, 10);
            return new DbResponse<SubMenuWithProductModel>(true, $"{menu.SubMenuName} Get Successfully", menu);
        }
        public List<ProductGridViewModel> Products(int subMenuId, int getFrom, int quantity)
        {
            return Db.Product
                .Where(p => p.SubMenuId == subMenuId)
                .OrderBy(p => p.ProductCode)
                .Skip(getFrom)
                .Take(quantity)
                .ProjectTo<ProductGridViewModel>(_mapper.ConfigurationProvider)
                .ToList();
        }
    }


}