using AutoMapper;
using MuslimFashion.Data;
using MuslimFashion.ViewModel;
using System.Linq;

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
    }
}