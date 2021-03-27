using MuslimFashion.ViewModel;
using System.Collections.Generic;

namespace MuslimFashion.BusinessLogic
{
    public interface IColorCore
    {
        DbResponse<ColorCrudModel> Add(ColorCrudModel model);
        DbResponse Edit(ColorCrudModel model);
        DbResponse Delete(int id);
        DbResponse<ColorCrudModel> Get(int id);
        List<ColorCrudModel> List();
        List<DDL> ListDdl();
    }
}