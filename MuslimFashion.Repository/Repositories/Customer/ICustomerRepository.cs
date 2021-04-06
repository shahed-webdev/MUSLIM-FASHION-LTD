using MuslimFashion.ViewModel;

namespace MuslimFashion.Repository
{
    public interface ICustomerRepository
    {
        void AddWithRegistration(CustomerAddWithRegistrationModel withRegistrationModel);

        bool IsExistPhone(string phone);
        bool IsExistPhone(string phone, int updateId);
    }
}