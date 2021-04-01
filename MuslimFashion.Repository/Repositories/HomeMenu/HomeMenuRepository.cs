using AutoMapper;
using AutoMapper.QueryableExtensions;
using MuslimFashion.Data;
using MuslimFashion.ViewModel;
using System.Collections.Generic;
using System.Linq;

namespace MuslimFashion.Repository
{
    public class HomeMenuRepository : Repository, IHomeMenuRepository
    {
        public HomeMenuRepository(ApplicationDbContext db, IMapper mapper) : base(db, mapper)
        {
        }

        public DbResponse<HomeMenuCrudModel> Add(HomeMenuCrudModel model)
        {
            var homeMenu = _mapper.Map<HomeMenu>(model);
            Db.HomeMenu.Add(homeMenu);
            Db.SaveChanges();
            model.HomeMenuId = homeMenu.HomeMenuId;

            return new DbResponse<HomeMenuCrudModel>(true, $"{model.HomeMenuName} Added Successfully", model);
        }

        public DbResponse Edit(HomeMenuCrudModel model)
        {
            var menu = Db.HomeMenu.Find(model.HomeMenuId);
            menu.HomeMenuName = model.HomeMenuName;
            menu.Sn = model.Sn;
            menu.ImageFileName = model.ImageFileName;
            Db.HomeMenu.Update(menu);
            Db.SaveChanges();
            return new DbResponse(true, $"{menu.HomeMenuName} Updated Successfully");
        }

        public DbResponse Delete(int id)
        {
            var homeMenu = Db.HomeMenu.Find(id);
            Db.HomeMenu.Remove(homeMenu);
            Db.SaveChanges();
            return new DbResponse(true, $"{homeMenu.HomeMenuName} Deleted Successfully");
        }

        public DbResponse<HomeMenuWithProductModel> Get(int id)
        {
            var menu = Db.HomeMenu.Where(r => r.HomeMenuId == id)
                .ProjectTo<HomeMenuWithProductModel>(_mapper.ConfigurationProvider)
                .FirstOrDefault();
            return new DbResponse<HomeMenuWithProductModel>(true, $"{menu.HomeMenuName} Get Successfully", menu);
        }

        public bool IsExistName(string name)
        {
            return Db.HomeMenu.Any(r => r.HomeMenuName == name);
        }

        public bool IsExistName(string name, int updateId)
        {
            return Db.HomeMenu.Any(r => r.HomeMenuName == name && r.HomeMenuId != updateId);
        }

        public bool IsNull(int id)
        {
            return Db.HomeMenu.Any(r => r.HomeMenuId == id);
        }

        public bool IsRelatedDataExist(int id)
        {
            return Db.HomeProduct.Any(r => r.HomeMenuId == id);
        }

        public List<HomeMenuCrudModel> List()
        {
            return Db.HomeMenu
                .ProjectTo<HomeMenuCrudModel>(_mapper.ConfigurationProvider)
                .OrderBy(a => a.HomeMenuName)
                .ToList();
        }

        public List<HomeMenuWithProductModel> ListWithProducts()
        {
            return Db.HomeMenu
                .ProjectTo<HomeMenuWithProductModel>(_mapper.ConfigurationProvider)
                .OrderBy(a => a.HomeMenuName)
                .ToList();
        }

        public List<DDL> ListDdl()
        {
            return Db.HomeMenu
                .OrderBy(a => a.HomeMenuName)
                .Select(m => new DDL
                {
                    value = m.HomeMenuId.ToString(),
                    label = m.HomeMenuName
                }).ToList();
        }
    }
}