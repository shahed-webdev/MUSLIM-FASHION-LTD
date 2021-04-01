using MuslimFashion.ViewModel;
using System.Collections.Generic;

namespace MuslimFashion.Repository
{
    public interface IHomeMenuRepository
    {
        DbResponse<HomeMenuCrudModel> Add(HomeMenuCrudModel model);
        DbResponse Edit(HomeMenuCrudModel model);
        DbResponse Delete(int id);
        DbResponse<HomeMenuWithProductModel> Get(int id);
        bool IsExistName(string name);
        bool IsExistName(string name, int updateId);
        bool IsNull(int id);
        bool IsRelatedDataExist(int id);
        List<HomeMenuCrudModel> List();
        List<HomeMenuWithProductModel> ListWithProducts();
        List<DDL> ListDdl();
    }
}