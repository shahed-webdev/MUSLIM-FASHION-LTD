using AutoMapper;
using MuslimFashion.Repository;
using MuslimFashion.ViewModel;
using System;
using System.Collections.Generic;

namespace MuslimFashion.BusinessLogic.Menu
{
    public class MenuCore : Core, IMenuCore
    {
        public MenuCore(IUnitOfWork db, IMapper mapper) : base(db, mapper)
        {
        }

        public DbResponse<MenuCrudModel> Add(MenuCrudModel model)
        {
            try
            {
                if (string.IsNullOrEmpty(model.MenuName))
                    return new DbResponse<MenuCrudModel>(false, "Invalid Data");

                if (_db.Menu.IsExistName(model.MenuName))
                    return new DbResponse<MenuCrudModel>(false, $" {model.MenuName} already Exist");

                return _db.Menu.Add(model);

            }
            catch (Exception e)
            {
                return new DbResponse<MenuCrudModel>(false, $"{e.Message}. {e.InnerException?.Message ?? ""}");
            }
        }

        public DbResponse Edit(MenuCrudModel model)
        {
            try
            {
                if (string.IsNullOrEmpty(model.MenuName))
                    return new DbResponse(false, "Invalid Data");

                if (!_db.Menu.IsNull(model.MenuId))
                    return new DbResponse(false, "No Data Found");

                if (_db.Menu.IsExistName(model.MenuName, model.MenuId))
                    return new DbResponse(false, $" {model.MenuName} already Exist");


                return _db.Menu.Edit(model);

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
                if (!_db.Menu.IsNull(id))
                    return new DbResponse(false, "No data Found");

                if (_db.Menu.IsRelatedDataExist(id))
                    return new DbResponse(false, "Failed, Sub-Menu already exist in this Menu");

                return _db.Menu.Delete(id);

            }
            catch (Exception e)
            {
                return new DbResponse(false, $"{e.Message}. {e.InnerException?.Message ?? ""}");
            }
        }

        public DbResponse<MenuCrudModel> Get(int id)
        {
            try
            {
                if (_db.Menu.IsNull(id))
                    return new DbResponse<MenuCrudModel>(false, "No data Found");

                return _db.Menu.Get(id);

            }
            catch (Exception e)
            {
                return new DbResponse<MenuCrudModel>(false, $"{e.Message}. {e.InnerException?.Message ?? ""}");
            }
        }

        public List<MenuCrudModel> List()
        {
            return _db.Menu.List();
        }

        public List<MenuWithSubMenuViewModel> ListWithSubMenu()
        {
            return _db.Menu.ListWithSubMenu();
        }

        public List<DDL> ListDdl()
        {
            return _db.Menu.ListDdl();
        }
    }
}