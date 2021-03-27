using JqueryDataTables.LoopsIT;
using MuslimFashion.ViewModel;

namespace MuslimFashion.Repository
{
    public interface IProductRepository
    {
        DbResponse<int> Add(ProductAddModel model);
        // DbResponse Edit(ColorCrudModel model);
        // DbResponse Delete(int id);
        DbResponse<ProductDetailsModel> Get(int id);
        bool IsExistName(string name);
        bool IsExistName(string name, int updateId);
        bool IsExistCode(string code);
        bool IsExistCode(string code, int updateId);
        bool IsNull(int id);
        bool IsRelatedDataExist(int id);

        DataResult<ProductRecordView> ListByAdmin(DataRequest request);

    }
}