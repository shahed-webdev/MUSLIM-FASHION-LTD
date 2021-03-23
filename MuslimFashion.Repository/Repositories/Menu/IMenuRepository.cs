using MuslimFashion.ViewModel;
using System.Collections.Generic;

namespace MuslimFashion.Repository
{
    public interface IMenuRepository
    {
        DbResponse<MenuCrudModel> Add(MenuCrudModel model);
        DbResponse Edit(MenuCrudModel model);
        DbResponse Delete(int id);
        DbResponse<MenuCrudModel> Get(int id);
        bool IsExistName(string name);
        bool IsExistName(string name, int updateId);
        bool IsNull(int id);
        bool IsRelatedDataExist(int id);
        List<MenuCrudModel> List();
        List<DDL> ListDdl();
    }
}