using Microsoft.AspNetCore.Http;
using MuslimFashion.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MuslimFashion.BusinessLogic
{
    public interface IHomeMenuCore
    {
        Task<DbResponse<HomeMenuCrudModel>> AddAsync(HomeMenuCrudModel model, IFormFile imageFile);
        Task<DbResponse> EditAsync(HomeMenuCrudModel model, IFormFile imageFile);
        DbResponse Delete(int id);
        DbResponse<HomeMenuWithProductModel> GetWithProducts(int id);
        DbResponse<HomeMenuCrudModel> Get(int id);
        List<HomeMenuCrudModel> List();
        List<HomeMenuWithProductModel> ListWithProducts();
        List<DDL> ListDdl();
        DbResponse AddProduct(HomeMenuAddRemoveProductModel model);
        DbResponse DeleteProduct(HomeMenuAddRemoveProductModel model);
        List<ProductGridViewModel> Products(int homeMenuId, int getFrom, int quantity);
    }
}