using AutoMapper;
using AutoMapper.QueryableExtensions;
using MuslimFashion.Data;
using MuslimFashion.ViewModel;
using System.Collections.Generic;
using System.Linq;

namespace MuslimFashion.Repository
{
    public class MenuRepository : Repository, IMenuRepository
    {
        public MenuRepository(ApplicationDbContext db, IMapper mapper) : base(db, mapper)
        {
        }

        public DbResponse<MenuCrudModel> Add(MenuCrudModel model)
        {
            var menu = _mapper.Map<Menu>(model);
            Db.Menu.Add(menu);
            Db.SaveChanges();
            model.MenuId = menu.MenuId;

            return new DbResponse<MenuCrudModel>(true, $"{model.MenuName} Added Successfully", model);
        }

        public DbResponse Edit(MenuCrudModel model)
        {
            var menu = Db.Menu.Find(model.MenuId);
            menu.MenuName = model.MenuName;
            Db.Menu.Update(menu);
            Db.SaveChanges();
            return new DbResponse(true, $"{menu.MenuName} Updated Successfully");
        }

        public DbResponse Delete(int id)
        {
            var menu = Db.Menu.Find(id);
            Db.Menu.Remove(menu);
            Db.SaveChanges();
            return new DbResponse(true, $"{menu.MenuName} Deleted Successfully");
        }

        public DbResponse<MenuCrudModel> Get(int id)
        {
            var menu = Db.Menu.Where(r => r.MenuId == id)
                .ProjectTo<MenuCrudModel>(_mapper.ConfigurationProvider)
                .FirstOrDefault();
            return new DbResponse<MenuCrudModel>(true, $"{menu.MenuName} Get Successfully", menu);
        }

        public bool IsExistName(string name)
        {
            return Db.Menu.Any(r => r.MenuName == name);
        }

        public bool IsExistName(string name, int updateId)
        {
            return Db.Menu.Any(r => r.MenuName == name && r.MenuId != updateId);
        }

        public bool IsNull(int id)
        {
            return Db.Menu.Any(r => r.MenuId == id);
        }

        public bool IsRelatedDataExist(int id)
        {
            return Db.SubMenu.Any(m => m.MenuId == id);
        }

        public List<MenuCrudModel> List()
        {
            return Db.Menu
                .ProjectTo<MenuCrudModel>(_mapper.ConfigurationProvider)
                .OrderBy(a => a.MenuName)
                .ToList();
        }

        public List<DDL> ListDdl()
        {
            return Db.Menu
                .OrderBy(a => a.MenuName)
                .Select(m => new DDL
                {
                    value = m.MenuId.ToString(),
                    label = m.MenuName
                }).ToList();
        }
    }
}