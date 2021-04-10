using AutoMapper;
using DevMaker.FileStorage;
using JqueryDataTables.LoopsIT;
using Microsoft.AspNetCore.Http;
using MuslimFashion.Repository;
using MuslimFashion.ViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MuslimFashion.BusinessLogic
{
    public class ProductCore : Core, IProductCore
    {
        public ProductCore(IUnitOfWork db, IMapper mapper) : base(db, mapper)
        {
        }

        public async Task<DbResponse<int>> AddAsync(ProductAddModel model, IFormFile imageFile)
        {
            try
            {
                if (string.IsNullOrEmpty(model.ProductName))
                    return new DbResponse<int>(false, "Invalid Data");

                if (_db.product.IsExistName(model.ProductName))
                    return new DbResponse<int>(false, $" {model.ProductName} already Exist");

                if (_db.product.IsExistCode(model.ProductCode))
                    return new DbResponse<int>(false, $" {model.ProductCode} Code already Exist");

                if (imageFile == null)
                    return new DbResponse<int>(false, $"No Product Image Added");

                var fileName = await FileStorage.UploadFileAsync(imageFile, "product-image");
                model.ImageFileName = fileName;

                if (string.IsNullOrEmpty(model.ImageFileName))
                    return new DbResponse<int>(false, $"No Product Image Added");

                return _db.product.Add(model);

            }
            catch (Exception e)
            {
                return new DbResponse<int>(false, $"{e.Message}. {e.InnerException?.Message ?? ""}");
            }
        }

        public async Task<DbResponse> EditAsync(ProductEditModel model, IFormFile imageFile)
        {
            try
            {
                if (string.IsNullOrEmpty(model.ProductName))
                    return new DbResponse(false, "Invalid Data");

                if (_db.product.IsExistName(model.ProductName, model.ProductId))
                    return new DbResponse(false, $" {model.ProductName} already Exist");

                if (_db.product.IsExistCode(model.ProductCode, model.ProductId))
                    return new DbResponse(false, $" {model.ProductCode} Code already Exist");

                return await _db.product.EditAsync(model, imageFile);

            }
            catch (Exception e)
            {
                return new DbResponse(false, $"{e.Message}. {e.InnerException?.Message ?? ""}");
            }
        }

        public DbResponse<ProductDetailsModel> Get(int id)
        {
            try
            {
                return !_db.product.IsNull(id) ? new DbResponse<ProductDetailsModel>(false, "No data Found") : _db.product.Get(id);
            }
            catch (Exception e)
            {
                return new DbResponse<ProductDetailsModel>(false, $"{e.Message}. {e.InnerException?.Message ?? ""}");
            }
        }

        public DataResult<ProductRecordView> ListByAdmin(DataRequest request)
        {
            return _db.product.ListByAdmin(request);
        }

        public DataResult<ProductRecordView> ListOfUnassignedHomeMenu(DataRequest request, int homeMenuId)
        {
            return _db.product.ListOfUnassignedHomeMenu(request, homeMenuId);
        }

        public DataResult<ProductRecordView> ListOfAssignedHomeMenu(DataRequest request, int homeMenuId)
        {
            return _db.product.ListOfAssignedHomeMenu(request, homeMenuId);
        }

        public async Task<List<ProductFindViewModel>> SearchAsync(string code)
        {
            return await _db.product.SearchAsync(code);
        }
    }
}