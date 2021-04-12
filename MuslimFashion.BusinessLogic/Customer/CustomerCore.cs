using AutoMapper;
using Microsoft.AspNetCore.Identity;
using MuslimFashion.Data;
using MuslimFashion.Repository;
using MuslimFashion.ViewModel;
using System;
using System.Collections.Generic;
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

        public DbResponse<CustomerAddressCrudModel> AddAddress(CustomerAddressCrudModel model, string userName)
        {
            try
            {
                model.CustomerId = _db.Registration.CustomerIdByUserName(userName);

                if (model.CustomerId == 0)
                    return new DbResponse<CustomerAddressCrudModel>(false, "Invalid User");

                if (_db.Customer.IsAddressLimitOver(model.CustomerId))
                    return new DbResponse<CustomerAddressCrudModel>(false, "Address Limit over");
                return _db.Customer.AddAddress(model);
            }
            catch (Exception e)
            {
                return new DbResponse<CustomerAddressCrudModel>(false, $"{e.Message}. {e.InnerException?.Message ?? ""}");
            }
        }

        public DbResponse DeleteAddress(int customerAddressId)
        {
            try
            {
                if (_db.Customer.IsAddressNull(customerAddressId))
                    return new DbResponse(false, "Address Not Found");
                return _db.Customer.DeleteAddress(customerAddressId);
            }
            catch (Exception e)
            {
                return new DbResponse(false, $"{e.Message}. {e.InnerException?.Message ?? ""}");
            }
        }

        public DbResponse EditAddress(CustomerAddressCrudModel model)
        {
            try
            {
                if (_db.Customer.IsAddressNull(model.CustomerAddressId))
                    return new DbResponse(false, "Address Not Found");
                return _db.Customer.EditAddress(model);
            }
            catch (Exception e)
            {
                return new DbResponse(false, $"{e.Message}. {e.InnerException?.Message ?? ""}");
            }
        }

        public List<CustomerAddressCrudModel> AddressList(string userName)
        {
            var customerId = _db.Registration.CustomerIdByUserName(userName);
            return _db.Customer.AddressList(customerId);
        }

        public Task<List<CustomerCrudModel>> SearchAsync(string key)
        {
            return _db.Customer.SearchAsync(key);
        }
    }
}