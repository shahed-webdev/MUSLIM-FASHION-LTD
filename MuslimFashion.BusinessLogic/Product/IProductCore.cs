using JqueryDataTables.LoopsIT;
using Microsoft.AspNetCore.Http;
using MuslimFashion.ViewModel;
using System.Threading.Tasks;

namespace MuslimFashion.BusinessLogic
{
    public interface IProductCore
    {
        Task<DbResponse<int>> AddAsync(ProductAddModel model, IFormFile imageFile);
        DbResponse<ProductDetailsModel> Get(int id);
        DataResult<ProductRecordView> ListByAdmin(DataRequest request);
    }
}