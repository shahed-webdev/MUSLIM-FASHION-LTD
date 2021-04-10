using Microsoft.AspNetCore.Http;
using MuslimFashion.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MuslimFashion.Repository
{
    public interface IHomeMenuRepository
    {
        DbResponse<HomeMenuCrudModel> Add(HomeMenuCrudModel model);
        Task<DbResponse> EditAsync(HomeMenuCrudModel model, IFormFile imageFile);
        DbResponse Delete(int id);
        DbResponse<HomeMenuWithProductModel> GetWithProducts(int id);
        DbResponse<HomeMenuCrudModel> Get(int id);
        bool IsExistName(string name);
        bool IsExistName(string name, int updateId);
        bool IsNull(int id);
        bool IsRelatedDataExist(int id);
        List<HomeMenuCrudModel> List();
        List<HomeMenuWithProductModel> ListWithProducts();
        List<DDL> ListDdl();
        DbResponse AddProduct(HomeMenuAddRemoveProductModel model);
        DbResponse DeleteProduct(HomeMenuAddRemoveProductModel model);
        List<ProductGridViewModel> Products(int homeMenuId, int getFrom, int quantity);
    }
}