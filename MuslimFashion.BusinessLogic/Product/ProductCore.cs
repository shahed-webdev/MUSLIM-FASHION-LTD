using AutoMapper;
using JqueryDataTables.LoopsIT;
using MuslimFashion.Repository;
using MuslimFashion.ViewModel;
using System;

namespace MuslimFashion.BusinessLogic
{
    public class ProductCore : Core, IProductCore
    {
        public ProductCore(IUnitOfWork db, IMapper mapper) : base(db, mapper)
        {
        }

        public DbResponse<int> Add(ProductAddModel model)
        {
            try
            {
                if (string.IsNullOrEmpty(model.ProductName))
                    return new DbResponse<int>(false, "Invalid Data");

                if (_db.product.IsExistName(model.ProductName))
                    return new DbResponse<int>(false, $" {model.ProductName} already Exist");

                if (_db.product.IsExistCode(model.ProductCode))
                    return new DbResponse<int>(false, $" {model.ProductCode} Code already Exist");

                if (string.IsNullOrEmpty(model.ImageFileName))
                    return new DbResponse<int>(false, $"No Product Image Added");

                return _db.product.Add(model);

            }
            catch (Exception e)
            {
                return new DbResponse<int>(false, $"{e.Message}. {e.InnerException?.Message ?? ""}");
            }
        }

        public DbResponse<ProductDetailsModel> Get(int id)
        {
            try
            {
                if (_db.product.IsNull(id))
                    return new DbResponse<ProductDetailsModel>(false, "No data Found");

                return _db.product.Get(id);

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
    }
}