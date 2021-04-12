using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using MuslimFashion.Data;
using MuslimFashion.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MuslimFashion.Repository
{
    public class CustomerRepository : Repository, ICustomerRepository
    {
        public CustomerRepository(ApplicationDbContext db, IMapper mapper) : base(db, mapper)
        {
        }

        public void AddWithRegistration(CustomerAddWithRegistrationModel withRegistrationModel)
        {
            var registration = _mapper.Map<Registration>(withRegistrationModel);
            registration.Type = UserType.Customer;
            Db.Registration.Add(registration);
            Db.SaveChanges();
        }

        public bool IsExistPhone(string phone)
        {
            return Db.Registration.Any(r => r.Phone == phone);
        }

        public bool IsExistPhone(string phone, int updateId)
        {
            return Db.Registration.Any(r => r.Phone == phone && r.RegistrationId != updateId);
        }

        public DbResponse<CustomerAddressCrudModel> AddAddress(CustomerAddressCrudModel model)
        {
            var address = _mapper.Map<CustomerAddress>(model);
            Db.CustomerAddresses.Add(address);
            Db.SaveChanges();
            model.CustomerAddressId = address.CustomerAddressId;

            return new DbResponse<CustomerAddressCrudModel>(true, $"Address Successfully added", model);
        }

        public DbResponse DeleteAddress(int customerAddressId)
        {
            var address = Db.CustomerAddresses.Find(customerAddressId);
            Db.CustomerAddresses.Remove(address);
            Db.SaveChanges();
            return new DbResponse(true, $"Address Successfully Deleted");
        }

        public DbResponse EditAddress(CustomerAddressCrudModel model)
        {
            var address = Db.CustomerAddresses.Find(model.CustomerAddressId);
            address.Phone = model.Phone;
            address.Address = model.Address;
            address.Name = model.Name;
            Db.CustomerAddresses.Update(address);
            Db.SaveChanges();
            return new DbResponse(true, $"Address Successfully Updated");
        }



        public bool IsAddressLimitOver(int customerId)
        {
            var count = Db.CustomerAddresses.Count(c => c.CustomerId == customerId);
            return count >= 3;
        }

        public List<CustomerAddressCrudModel> AddressList(int customerId)
        {
            return Db.CustomerAddresses.Where(a => a.CustomerId == customerId)
                .ProjectTo<CustomerAddressCrudModel>(_mapper.ConfigurationProvider)
                .ToList();
        }

        public bool IsAddressNull(int customerAddressId)
        {
            return !Db.CustomerAddresses.Any(c => c.CustomerAddressId == customerAddressId);
        }

        public async Task<List<CustomerCrudModel>> SearchAsync(string key)
        {
            return await Db.Customer
                .Where(c => c.Phone.Contains(key) || c.Name.Contains(key))
                .ProjectTo<CustomerCrudModel>(_mapper.ConfigurationProvider)
                .Take(4)
                .ToListAsync()
                .ConfigureAwait(false);
        }
    }
}