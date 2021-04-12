using Microsoft.AspNetCore.Identity;
using MuslimFashion.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MuslimFashion.BusinessLogic
{
    public interface ICustomerCore
    {
        Task<DbResponse<IdentityUser>> AddWithRegistrationAsync(CustomerAddWithRegistrationModel withRegistrationModel);

        DbResponse<CustomerAddressCrudModel> AddAddress(CustomerAddressCrudModel model, string userName);
        DbResponse DeleteAddress(int customerAddressId);
        DbResponse EditAddress(CustomerAddressCrudModel model);
        List<CustomerAddressCrudModel> AddressList(string userName);
        Task<List<CustomerCrudModel>> SearchAsync(string key);
    }
}