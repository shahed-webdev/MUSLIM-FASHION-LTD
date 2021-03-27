using MuslimFashion.ViewModel;
using System.Collections.Generic;

namespace MuslimFashion.Repository
{
    public interface ISizeRepository
    {
        DbResponse<SizeCrudModel> Add(SizeCrudModel model);
        DbResponse Edit(SizeCrudModel model);
        DbResponse Delete(int id);
        DbResponse<SizeCrudModel> Get(int id);
        bool IsExistName(string name);
        bool IsExistName(string name, int updateId);
        bool IsNull(int id);
        bool IsRelatedDataExist(int id);
        List<SizeCrudModel> List();
        List<DDL> ListDdl();
    }
}