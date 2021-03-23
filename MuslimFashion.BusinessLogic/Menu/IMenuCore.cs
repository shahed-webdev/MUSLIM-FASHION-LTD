using MuslimFashion.ViewModel;
using System.Collections.Generic;

namespace MuslimFashion.BusinessLogic.Menu
{
    public interface IMenuCore
    {
        DbResponse<MenuCrudModel> Add(MenuCrudModel model);
        DbResponse Edit(MenuCrudModel model);
        DbResponse Delete(int id);
        DbResponse<MenuCrudModel> Get(int id);
        List<MenuCrudModel> List();
        List<DDL> ListDdl();
    }
}