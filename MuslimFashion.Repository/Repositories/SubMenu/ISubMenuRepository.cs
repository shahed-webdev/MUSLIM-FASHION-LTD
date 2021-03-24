using MuslimFashion.ViewModel;
using System.Collections.Generic;

namespace MuslimFashion.Repository
{
    public interface ISubMenuRepository
    {

        DbResponse<SubMenuAddEditModel> Add(SubMenuAddEditModel model);
        DbResponse Edit(SubMenuAddEditModel model);
        DbResponse Delete(int id);
        DbResponse<SubMenuWithMenuModel> Get(int id);
        bool IsExistName(string name, int menuId);
        bool IsExistName(string name, int menuId, int updateId);
        bool IsNull(int id);
        bool IsRelatedDataExist(int id);
        List<SubMenuViewModel> MenuWiseList(int menuId);
        List<DDL> MenuWiseDdlList(int menuId);
    }
}