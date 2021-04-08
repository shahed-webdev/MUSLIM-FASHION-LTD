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

        public DbResponse<HomeMenuWithProductModel> GetWithProducts(int id)
        {
            var homeMenu = Db.HomeMenu.Where(r => r.HomeMenuId == id)
                .ProjectTo<HomeMenuWithProductModel>(_mapper.ConfigurationProvider)
                .FirstOrDefault();
            homeMenu.Products = Products(homeMenu.HomeMenuId, 0, 10);
            return new DbResponse<HomeMenuWithProductModel>(true, $"{homeMenu.HomeMenuName} Get Successfully", homeMenu);
        }

        public DbResponse<HomeMenuCrudModel> Get(int id)
        {
            var homeMenu = Db.HomeMenu.Where(r => r.HomeMenuId == id)
                .ProjectTo<HomeMenuCrudModel>(_mapper.ConfigurationProvider)
                .FirstOrDefault();

            return new DbResponse<HomeMenuCrudModel>(true, $"{homeMenu.HomeMenuName} Get Successfully", homeMenu);
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
                .OrderBy(m => m.Sn)
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
                ProductId = p,
                HomeMenuId = model.HomeMenuId
            }).ToList();

            var newProducts = homeProducts.Where(h =>
                 !Db.HomeProduct.Any(p => p.HomeMenuId == h.HomeMenuId && p.ProductId == h.ProductId)).ToList();
            if (!newProducts.Any())
                return new DbResponse(true, $"Product already Added");
            Db.HomeProduct.AddRange(newProducts);
            Db.SaveChanges();

            return new DbResponse(true, $"Product Added Successfully");
        }

        public DbResponse DeleteProduct(HomeMenuDeleteProductModel model)
        {
            var homeProduct = Db.HomeProduct.FirstOrDefault(r => r.HomeMenuId == model.HomeMenuId && r.HomeProductId == model.ProductId);
            Db.HomeProduct.Remove(homeProduct);
            Db.SaveChanges();
            return new DbResponse(true, $"Product Deleted Successfully");
        }

        public List<ProductGridViewModel> Products(int homeMenuId, int getFrom, int quantity)
        {
            return Db.HomeProduct
                .Where(p => p.HomeMenuId == homeMenuId)
                .Skip(getFrom)
                .Take(quantity)
                .Select(p => p.Product)
                .ProjectTo<ProductGridViewModel>(_mapper.ConfigurationProvider)
                .ToList();
        }
    }
}