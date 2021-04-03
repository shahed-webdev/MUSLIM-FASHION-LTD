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
        bool IsExistProduct(HomeMenuDeleteProductModel model);
        bool IsRelatedDataExist(int id);
        List<HomeMenuCrudModel> List();
        List<HomeMenuWithProductModel> ListWithProducts();
        List<DDL> ListDdl();
        DbResponse AddProduct(HomeMenuAddProductModel model);
        DbResponse DeleteProduct(HomeMenuDeleteProductModel model);
        List<ProductGridViewModel> Products(int homeMenuId, int getFrom, int quantity);
    }
}