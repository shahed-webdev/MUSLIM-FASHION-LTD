using MuslimFashion.ViewModel;
using System.Collections.Generic;

namespace MuslimFashion.BusinessLogic
{
    public interface ISizeCore
    {
        DbResponse<SizeCrudModel> Add(SizeCrudModel model);
        DbResponse Edit(SizeCrudModel model);
        DbResponse Delete(int id);
        DbResponse<SizeCrudModel> Get(int id);
        List<SizeCrudModel> List();
        List<DDL> ListDdl();
    }
}