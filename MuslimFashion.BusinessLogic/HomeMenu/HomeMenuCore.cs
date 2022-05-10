using AutoMapper;
using DevMaker.FileStorage;
using Microsoft.AspNetCore.Http;
using MuslimFashion.Repository;
using MuslimFashion.ViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MuslimFashion.BusinessLogic
{
    public class HomeMenuCore : Core, IHomeMenuCore
    {
        public HomeMenuCore(IUnitOfWork db, IMapper mapper) : base(db, mapper)
        {
        }

        public async Task<DbResponse<HomeMenuCrudModel>> AddAsync(HomeMenuCrudModel model, IFormFile imageFile)
        {
            try
            {
                if (string.IsNullOrEmpty(model.HomeMenuName))
                    return new DbResponse<HomeMenuCrudModel>(false, "Invalid Data");

                if (_db.HomeMenu.IsExistName(model.HomeMenuName))
                    return new DbResponse<HomeMenuCrudModel>(false, $" {model.HomeMenuName} already Exist");

                if (imageFile != null)
                {
                    var fileName = await FileStorage.UploadFileAsync(imageFile, model.HomeMenuName);
                    model.ImageFileName = fileName;
                }

                return _db.HomeMenu.Add(model);

            }
            catch (Exception e)
            {
                return new DbResponse<HomeMenuCrudModel>(false, $"{e.Message}. {e.InnerException?.Message ?? ""}");
            }
        }

        public async Task<DbResponse> EditAsync(HomeMenuCrudModel model, IFormFile imageFile)
        {
            try
            {
                if (string.IsNullOrEmpty(model.HomeMenuName))
                    return new DbResponse(false, "Invalid Data");

                if (_db.HomeMenu.IsNull(model.HomeMenuId))
                    return new DbResponse(false, "No Data Found");

                if (_db.HomeMenu.IsExistName(model.HomeMenuName, model.HomeMenuId))
                    return new DbResponse(false, $" {model.HomeMenuName} already Exist");

                return await _db.HomeMenu.EditAsync(model, imageFile);
            }
            catch (Exception e)
            {
                return new DbResponse(false, $"{e.Message}. {e.InnerException?.Message ?? ""}");
            }
        }

        public DbResponse Delete(int id)
        {
            try
            {
                if (_db.HomeMenu.IsNull(id))
                    return new DbResponse(false, "No data Found");

                if (_db.HomeMenu.IsRelatedDataExist(id))
                    return new DbResponse(false, "Failed, Product already exist in this Menu");

                return _db.HomeMenu.Delete(id);

            }
            catch (Exception e)
            {
                return new DbResponse(false, $"{e.Message}. {e.InnerException?.Message ?? ""}");
            }
        }

        public DbResponse<HomeMenuWithProductModel> GetWithProducts(int id)
        {
            try
            {
                if (_db.HomeMenu.IsNull(id))
                    return new DbResponse<HomeMenuWithProductModel>(false, "No data Found");

                return _db.HomeMenu.GetWithProducts(id);

            }
            catch (Exception e)
            {
                return new DbResponse<HomeMenuWithProductModel>(false, $"{e.Message}. {e.InnerException?.Message ?? ""}");
            }
        }

        public DbResponse<HomeMenuCrudModel> Get(int id)
        {
            try
            {
                if (_db.HomeMenu.IsNull(id))
                    return new DbResponse<HomeMenuCrudModel>(false, "No data Found");

                return _db.HomeMenu.Get(id);

            }
            catch (Exception e)
            {
                return new DbResponse<HomeMenuCrudModel>(false, $"{e.Message}. {e.InnerException?.Message ?? ""}");
            }
        }

        public List<HomeMenuCrudModel> List()
        {
            return _db.HomeMenu.List();
        }

        public List<HomeMenuWithProductModel> ListWithProducts()
        {
            var homeMenus = _db.HomeMenu.ListWithProducts();
            foreach (var menu in homeMenus)
            {
                menu.Products = _db.HomeMenu.Products(menu.HomeMenuId, 0, 8);
            }
            return homeMenus;
        }

        public List<DDL> ListDdl()
        {
            return _db.HomeMenu.ListDdl();
        }

        public DbResponse AddProduct(HomeMenuAddRemoveProductModel model)
        {
            try
            {
                if (model.ProductIds.Length <= 0)
                    return new DbResponse(false, "Product not selected");

                if (_db.HomeMenu.IsNull(model.HomeMenuId))
                    return new DbResponse(false, "Menu not Fount");

                return _db.HomeMenu.AddProduct(model);


            }
            catch (Exception e)
            {
                return new DbResponse(false, $"{e.Message}. {e.InnerException?.Message ?? ""}");
            }
        }

        public DbResponse DeleteProduct(HomeMenuAddRemoveProductModel model)
        {
            try
            {
                return _db.HomeMenu.DeleteProduct(model);

            }
            catch (Exception e)
            {
                return new DbResponse(false, $"{e.Message}. {e.InnerException?.Message ?? ""}");
            }
        }

        public List<ProductGridViewModel> Products(int homeMenuId, int getFrom, int quantity)
        {
            return _db.HomeMenu.Products(homeMenuId, getFrom, quantity);
        }
    }
}