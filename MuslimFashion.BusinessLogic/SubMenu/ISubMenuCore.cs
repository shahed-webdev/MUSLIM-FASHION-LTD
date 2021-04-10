using MuslimFashion.ViewModel;
using System.Collections.Generic;

namespace MuslimFashion.BusinessLogic
{
    public interface ISubMenuCore
    {
        DbResponse<SubMenuAddEditModel> Add(SubMenuAddEditModel model);
        DbResponse Edit(SubMenuAddEditModel model);
        DbResponse Delete(int id);
        DbResponse<SubMenuWithMenuModel> Get(int id);
        List<SubMenuViewModel> MenuWiseList(int menuId);
        List<DDL> MenuWiseDdlList(int menuId);
        List<ProductGridViewModel> Products(int subMenuId, int getFrom, int quantity);
        DbResponse<SubMenuWithProductModel> GetWithProducts(int id);
    }

}