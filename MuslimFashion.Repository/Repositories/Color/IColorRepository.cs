using MuslimFashion.ViewModel;
using System.Collections.Generic;

namespace MuslimFashion.Repository
{
    public interface IColorRepository
    {
        DbResponse<ColorCrudModel> Add(ColorCrudModel model);
        DbResponse Edit(ColorCrudModel model);
        DbResponse Delete(int id);
        DbResponse<ColorCrudModel> Get(int id);
        bool IsExistName(string name);
        bool IsExistName(string name, int updateId);
        bool IsExistCode(string code);
        bool IsExistCode(string code, int updateId);
        bool IsNull(int id);
        bool IsRelatedDataExist(int id);
        List<ColorCrudModel> List();
        List<DDL> ListDdl();
    }
}