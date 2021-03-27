using AutoMapper;
using MuslimFashion.Repository;
using MuslimFashion.ViewModel;
using System;
using System.Collections.Generic;

namespace MuslimFashion.BusinessLogic
{
    public class SizeCore : Core, ISizeCore
    {
        public SizeCore(IUnitOfWork db, IMapper mapper) : base(db, mapper)
        {
        }

        public DbResponse<SizeCrudModel> Add(SizeCrudModel model)
        {
            try
            {
                if (string.IsNullOrEmpty(model.SizeName))
                    return new DbResponse<SizeCrudModel>(false, "Invalid Data");

                if (_db.Size.IsExistName(model.SizeName))
                    return new DbResponse<SizeCrudModel>(false, $" {model.SizeName} already Exist");

                return _db.Size.Add(model);

            }
            catch (Exception e)
            {
                return new DbResponse<SizeCrudModel>(false, $"{e.Message}. {e.InnerException?.Message ?? ""}");
            }
        }

        public DbResponse Edit(SizeCrudModel model)
        {
            try
            {
                if (string.IsNullOrEmpty(model.SizeName))
                    return new DbResponse(false, "Invalid Data");

                if (_db.Size.IsNull(model.SizeId))
                    return new DbResponse(false, "No Data Found");

                if (_db.Size.IsExistName(model.SizeName, model.SizeId))
                    return new DbResponse(false, $" {model.SizeName} already Exist");

                return _db.Size.Edit(model);

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
                if (_db.Size.IsNull(id))
                    return new DbResponse(false, "No data Found");

                if (_db.Size.IsRelatedDataExist(id))
                    return new DbResponse(false, $"Failed, Size already exist in the product");

                return _db.Size.Delete(id);

            }
            catch (Exception e)
            {
                return new DbResponse(false, $"{e.Message}. {e.InnerException?.Message ?? ""}");
            }
        }

        public DbResponse<SizeCrudModel> Get(int id)
        {
            try
            {
                if (_db.Menu.IsNull(id))
                    return new DbResponse<SizeCrudModel>(false, "No data Found");

                return _db.Size.Get(id);

            }
            catch (Exception e)
            {
                return new DbResponse<SizeCrudModel>(false, $"{e.Message}. {e.InnerException?.Message ?? ""}");
            }
        }

        public List<SizeCrudModel> List()
        {
            return _db.Size.List();
        }

        public List<DDL> ListDdl()
        {
            return _db.Size.ListDdl();
        }
    }
}