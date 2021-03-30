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


        public async Task<DbResponse<IdentityUser>> AddAsync(CustomerAddModel model)
        {
            try
            {
                if (string.IsNullOrEmpty(model.UserName) || string.IsNullOrEmpty(model.Phone))
                    return new DbResponse<IdentityUser>(false, "Invalid Data");

                if (_db.Customer.IsExistPhone(model.Phone))
                    return new DbResponse<IdentityUser>(false, $" {model.Phone} already Exist");

                //Identity Create
                var user = new IdentityUser { UserName = model.UserName, Email = model.Email };
                var password = model.Password;

                var result = await _userManager.CreateAsync(user, password).ConfigureAwait(false);

                if (!result.Succeeded) return new DbResponse<IdentityUser>(false, result.Errors.FirstOrDefault()?.Description);

                await _userManager.AddToRoleAsync(user, UserType.Customer.ToString()).ConfigureAwait(false);

                _db.Customer.Add(model);

                return new DbResponse<IdentityUser>(true, "Success", user);
            }
            catch (Exception e)
            {
                return new DbResponse<IdentityUser>(false, e.Message);
            }
        }
    }
}