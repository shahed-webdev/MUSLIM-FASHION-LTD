using AutoMapper;
using Microsoft.AspNetCore.Identity;
using MuslimFashion.Data;
using MuslimFashion.Repository;
using MuslimFashion.ViewModel;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MuslimFashion.BusinessLogic
{
    public class CustomerCore : Core, ICustomerCore
    {
        private readonly UserManager<IdentityUser> _userManager;
        public CustomerCore(IUnitOfWork db, IMapper mapper, UserManager<IdentityUser> userManager) : base(db, mapper)
        {
            _userManager = userManager;
        }


        public async Task<DbResponse<IdentityUser>> AddWithRegistrationAsync(CustomerAddWithRegistrationModel withRegistrationModel)
        {
            try
            {
                if (string.IsNullOrEmpty(withRegistrationModel.UserName) || string.IsNullOrEmpty(withRegistrationModel.Phone))
                    return new DbResponse<IdentityUser>(false, "UserName or mobile number empty", null, "UserName");

                if (_db.Customer.IsExistPhone(withRegistrationModel.Phone))
                    return new DbResponse<IdentityUser>(false, $" {withRegistrationModel.Phone} already Exist", null, "Phone");

                //Identity Create
                var user = new IdentityUser { UserName = withRegistrationModel.UserName, Email = withRegistrationModel.Email };
                var password = withRegistrationModel.Password;

                var result = await _userManager.CreateAsync(user, password).ConfigureAwait(false);

                if (!result.Succeeded) return new DbResponse<IdentityUser>(false, result.Errors.FirstOrDefault()?.Description, null, "CustomError");

                await _userManager.AddToRoleAsync(user, UserType.Customer.ToString()).ConfigureAwait(false);

                _db.Customer.AddWithRegistration(withRegistrationModel);

                return new DbResponse<IdentityUser>(true, "Success", user);
            }
            catch (Exception e)
            {
                return new DbResponse<IdentityUser>(false, e.Message);
            }
        }
    }
}