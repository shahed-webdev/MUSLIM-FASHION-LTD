using MuslimFashion.ViewModel;

namespace MuslimFashion.Repository
{
    public interface ICustomerRepository
    {
        void Add(CustomerAddModel model);

        bool IsExistPhone(string phone);
        bool IsExistPhone(string phone, int updateId);
    }
}