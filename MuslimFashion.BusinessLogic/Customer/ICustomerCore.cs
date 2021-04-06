using Microsoft.AspNetCore.Identity;
using MuslimFashion.ViewModel;
using System.Threading.Tasks;

namespace MuslimFashion.BusinessLogic
{
    public interface ICustomerCore
    {
        Task<DbResponse<IdentityUser>> AddWithRegistrationAsync(CustomerAddWithRegistrationModel withRegistrationModel);
    }
}