using MuslimFashion.ViewModel;

namespace MuslimFashion.BusinessLogic
{
    public interface IProductCore
    {
        DbResponse<int> Add(ProductAddModel model);
        DbResponse<ProductDetailsModel> Get(int id);
    }
}