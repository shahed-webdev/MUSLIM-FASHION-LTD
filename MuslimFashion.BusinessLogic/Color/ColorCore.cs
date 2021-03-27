using AutoMapper;
using MuslimFashion.Repository;
using MuslimFashion.ViewModel;
using System;
using System.Collections.Generic;

namespace MuslimFashion.BusinessLogic
{
    public class ColorCore : Core, IColorCore
    {
        public ColorCore(IUnitOfWork db, IMapper mapper) : base(db, mapper)
        {
        }


        public DbResponse<ColorCrudModel> Add(ColorCrudModel model)
        {
            try
            {
                if (string.IsNullOrEmpty(model.ColorName))
                    return new DbResponse<ColorCrudModel>(false, "Invalid Data");

                if (_db.Color.IsExistName(model.ColorName))
                    return new DbResponse<ColorCrudModel>(false, $" {model.ColorName} already Exist");

                if (_db.Color.IsExistCode(model.ColorCode))
                    return new DbResponse<ColorCrudModel>(false, $" {model.ColorCode} Code already Exist");

                return _db.Color.Add(model);

            }
            catch (Exception e)
            {
                return new DbResponse<ColorCrudModel>(false, $"{e.Message}. {e.InnerException?.Message ?? ""}");
            }
        }

        public DbResponse Edit(ColorCrudModel model)
        {
            try
            {
                if (string.IsNullOrEmpty(model.ColorName))
                    return new DbResponse(false, "Invalid Data");

                if (!_db.Color.IsNull(model.ColorId))
                    return new DbResponse(false, "No Data Found");

                if (_db.Color.IsExistName(model.ColorName, model.ColorId))
                    return new DbResponse(false, $" {model.ColorName} already Exist");

                if (_db.Color.IsExistCode(model.ColorCode, model.ColorId))
                    return new DbResponse(false, $" {model.ColorCode} Code already Exist");

                return _db.Color.Edit(model);

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
                if (!_db.Color.IsNull(id))
                    return new DbResponse(false, "No data Found");

                if (_db.Color.IsRelatedDataExist(id))
                    return new DbResponse(false, "Failed, color already exist in the product");

                return _db.Color.Delete(id);

            }
            catch (Exception e)
            {
                return new DbResponse(false, $"{e.Message}. {e.InnerException?.Message ?? ""}");
            }
        }

        public DbResponse<ColorCrudModel> Get(int id)
        {
            try
            {
                if (_db.Menu.IsNull(id))
                    return new DbResponse<ColorCrudModel>(false, "No data Found");

                return _db.Color.Get(id);

            }
            catch (Exception e)
            {
                return new DbResponse<ColorCrudModel>(false, $"{e.Message}. {e.InnerException?.Message ?? ""}");
            }
        }

        public List<ColorCrudModel> List()
        {
            return _db.Color.List();
        }

        public List<DDL> ListDdl()
        {
            return _db.Color.ListDdl();
        }
    }
}