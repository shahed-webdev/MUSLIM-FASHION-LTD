using MuslimFashion.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MuslimFashion.Repository
{
    public interface ICustomerRepository
    {
        void AddWithRegistration(CustomerAddWithRegistrationModel withRegistrationModel);

        bool IsExistPhone(string phone);
        bool IsExistPhone(string phone, int updateId);

        DbResponse<CustomerAddressCrudModel> AddAddress(CustomerAddressCrudModel model);
        DbResponse DeleteAddress(int customerAddressId);
        DbResponse EditAddress(CustomerAddressCrudModel model);
        bool IsAddressLimitOver(int customerId);
        List<CustomerAddressCrudModel> AddressList(int customerId);

        bool IsAddressNull(int customerAddressId);

        Task<List<CustomerCrudModel>> SearchAsync(string key);
    }
}