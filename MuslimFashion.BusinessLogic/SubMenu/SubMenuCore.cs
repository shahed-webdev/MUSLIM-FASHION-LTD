using AutoMapper;
using MuslimFashion.Repository;
using MuslimFashion.ViewModel;
using System;
using System.Collections.Generic;

namespace MuslimFashion.BusinessLogic
{
    public class SubMenuCore : Core, ISubMenuCore
    {
        public SubMenuCore(IUnitOfWork db, IMapper mapper) : base(db, mapper)
        {
        }

        public DbResponse<SubMenuAddEditModel> Add(SubMenuAddEditModel model)
        {
            try
            {
                if (string.IsNullOrEmpty(model.SubMenuName))
                    return new DbResponse<SubMenuAddEditModel>(false, "Invalid Data");

                if (_db.SubMenu.IsExistName(model.SubMenuName, model.MenuId))
                    return new DbResponse<SubMenuAddEditModel>(false, $" {model.SubMenuName} already Exist");

                return _db.SubMenu.Add(model);

            }
            catch (Exception e)
            {
                return new DbResponse<SubMenuAddEditModel>(false, $"{e.Message}. {e.InnerException?.Message ?? ""}");
            }
        }

        public DbResponse Edit(SubMenuAddEditModel model)
        {
            try
            {
                if (string.IsNullOrEmpty(model.SubMenuName))
                    return new DbResponse(false, "Invalid Data");

                if (!_db.SubMenu.IsNull(model.SubMenuId))
                    return new DbResponse(false, "No Data Found");

                if (_db.SubMenu.IsExistName(model.SubMenuName, model.MenuId, model.SubMenuId))
                    return new DbResponse(false, $" {model.SubMenuName} already Exist");


                return _db.SubMenu.Edit(model);

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
                if (!_db.SubMenu.IsNull(id))
                    return new DbResponse(false, "No data Found");

                if (_db.SubMenu.IsRelatedDataExist(id))
                    return new DbResponse(false, "Failed, Product already exist in this SubMenu");

                return _db.SubMenu.Delete(id);

            }
            catch (Exception e)
            {
                return new DbResponse(false, $"{e.Message}. {e.InnerException?.Message ?? ""}");
            }
        }

        public DbResponse<SubMenuWithMenuModel> Get(int id)
        {
            try
            {
                if (_db.SubMenu.IsNull(id))
                    return new DbResponse<SubMenuWithMenuModel>(false, "No data Found");

                return _db.SubMenu.Get(id);

            }
            catch (Exception e)
            {
                return new DbResponse<SubMenuWithMenuModel>(false, $"{e.Message}. {e.InnerException?.Message ?? ""}");
            }
        }

        public List<SubMenuViewModel> MenuWiseList(int menuId)
        {
            return _db.SubMenu.MenuWiseList(menuId);
        }

        public List<DDL> MenuWiseDdlList(int menuId)
        {
            return _db.SubMenu.MenuWiseDdlList(menuId);
        }

        public DbResponse<SubMenuWithProductModel> GetWithProducts(int id)
        {
            try
            {
                if (!_db.SubMenu.IsNull(id))
                    return new DbResponse<SubMenuWithProductModel>(false, "No data Found");

                return _db.SubMenu.GetWithProducts(id);

            }
            catch (Exception e)
            {
                return new DbResponse<SubMenuWithProductModel>(false, $"{e.Message}. {e.InnerException?.Message ?? ""}");
            }
        }
        public List<ProductGridViewModel> Products(int subMenuId, int getFrom, int quantity)
        {
            return _db.SubMenu.Products(subMenuId, getFrom, quantity);
        }
    }
}