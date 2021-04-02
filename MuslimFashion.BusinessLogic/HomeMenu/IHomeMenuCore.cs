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
        DbResponse<HomeMenuWithProductModel> Get(int id);
        List<HomeMenuCrudModel> List();
        List<HomeMenuWithProductModel> ListWithProducts();
        List<DDL> ListDdl();
        DbResponse AddProduct(HomeMenuAddProductModel model);
        DbResponse DeleteProduct(HomeMenuDeleteProductModel model);
    }
}