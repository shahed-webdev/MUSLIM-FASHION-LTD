using JqueryDataTables.LoopsIT;
using Microsoft.AspNetCore.Http;
using MuslimFashion.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MuslimFashion.BusinessLogic
{
    public interface IProductCore
    {
        Task<DbResponse<int>> AddAsync(ProductAddModel model, IFormFile imageFile);
        Task<DbResponse> EditAsync(ProductEditModel model, IFormFile imageFile);
        DbResponse<ProductDetailsModel> Get(int id);
        DataResult<ProductRecordView> ListByAdmin(DataRequest request);
        DataResult<ProductRecordView> ListOfUnassignedHomeMenu(DataRequest request, int homeMenuId);
        DataResult<ProductRecordView> ListOfAssignedHomeMenu(DataRequest request, int homeMenuId);

        Task<List<ProductFindViewModel>> SearchAsync(string code);
    }
}