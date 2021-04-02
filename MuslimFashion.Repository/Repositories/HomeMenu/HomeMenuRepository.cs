using AutoMapper;
using AutoMapper.QueryableExtensions;
using DevMaker.FileStorage;
using Microsoft.AspNetCore.Http;
using MuslimFashion.Data;
using MuslimFashion.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public async Task<DbResponse> EditAsync(HomeMenuCrudModel model, IFormFile imageFile)
        {
            var homeMenu = await Db.HomeMenu.FindAsync(model.HomeMenuId);
            homeMenu.HomeMenuName = model.HomeMenuName;
            homeMenu.Sn = model.Sn;

            if (imageFile != null)
            {
                var fileName = await FileStorage.UploadFileAsync(imageFile, model.HomeMenuName);
                homeMenu.ImageFileName = fileName;

                if (!string.IsNullOrEmpty(homeMenu.ImageFileName)) FileStorage.DeleteFile(homeMenu.ImageFileName);
            }

            Db.HomeMenu.Update(homeMenu);
            await Db.SaveChangesAsync();
            return new DbResponse(true, $"{homeMenu.HomeMenuName} Updated Successfully");
        }

        public DbResponse Delete(int id)
        {
            var homeMenu = Db.HomeMenu.Find(id);
            if (!string.IsNullOrEmpty(homeMenu.ImageFileName)) FileStorage.DeleteFile(homeMenu.ImageFileName);
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
            return !Db.HomeMenu.Any(r => r.HomeMenuId == id);
        }

        public bool IsExistProduct(HomeMenuDeleteProductModel model)
        {
            return Db.HomeProduct.Any(r => r.HomeMenuId == model.HomeMenuId && r.HomeProductId == model.ProductId);
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

        public DbResponse AddProduct(HomeMenuAddProductModel model)
        {
            var homeProducts = model.ProductIds.Select(p => new HomeProduct
            {
                ProductId = model.HomeMenuId,
                HomeMenuId = p
            }).ToList();
            Db.HomeProduct.AddRange(homeProducts);
            Db.SaveChanges();

            return new DbResponse(true, $"Product added Added Successfully");
        }

        public DbResponse DeleteProduct(HomeMenuDeleteProductModel model)
        {
            var homeProduct = Db.HomeProduct.FirstOrDefault(r => r.HomeMenuId == model.HomeMenuId && r.HomeProductId == model.ProductId);
            Db.HomeProduct.Remove(homeProduct);
            Db.SaveChanges();
            return new DbResponse(true, $"Product Deleted Successfully");
        }
    }
}