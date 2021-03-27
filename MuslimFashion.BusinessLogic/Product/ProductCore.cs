using AutoMapper;
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

                if (_db.Color.IsExistName(model.ProductName))
                    return new DbResponse<int>(false, $" {model.ProductName} already Exist");

                if (_db.Color.IsExistCode(model.ProductCode))
                    return new DbResponse<int>(false, $" {model.ProductCode} Code already Exist");

                if (model.ImageFileNames.Length <= 0)
                    return new DbResponse<int>(false, $"No Product Image Added");

                return _db.product.Add(model);

            }
            catch (Exception e)
            {
                return new DbResponse<int>(false, $"{e.Message}. {e.InnerException?.Message ?? ""}");
            }
        }
    }
}