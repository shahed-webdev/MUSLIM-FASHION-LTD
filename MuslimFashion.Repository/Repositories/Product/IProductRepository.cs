using JqueryDataTables.LoopsIT;
using Microsoft.AspNetCore.Http;
using MuslimFashion.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MuslimFashion.Repository
{
    public interface IProductRepository
    {
        DbResponse<int> Add(ProductAddModel model);
        Task<DbResponse> EditAsync(ProductEditModel model, IFormFile imageFile);
        // DbResponse Delete(int id);
        DbResponse<ProductDetailsModel> Get(int id);
        bool IsExistName(string name);
        bool IsExistName(string name, int updateId);
        bool IsExistCode(string code);
        bool IsExistCode(string code, int updateId);
        bool IsNull(int id);
        bool IsRelatedDataExist(int id);

        DataResult<ProductRecordView> ListByAdmin(DataRequest request);
        DataResult<ProductRecordView> ListOfUnassignedHomeMenu(DataRequest request, int homeMenuId);
        DataResult<ProductRecordView> ListOfAssignedHomeMenu(DataRequest request, int homeMenuId);
        Task<List<ProductFindViewModel>> SearchAsync(string code);

    }
}