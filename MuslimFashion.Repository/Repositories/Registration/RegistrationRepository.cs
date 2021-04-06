using AutoMapper;
using MuslimFashion.Data;
using System.Linq;

namespace MuslimFashion.Repository
{
    public class RegistrationRepository : Repository, IRegistrationRepository
    {
        public RegistrationRepository(ApplicationDbContext db, IMapper mapper) : base(db, mapper)
        {
        }
        public int CustomerIdByUserName(string userName)
        {
            return Db.Customer.FirstOrDefault(r => r.Registration.UserName == userName)?.CustomerId ?? 0;
        }
        public UserType UserTypeByUserName(string userName)
        {
            return Db.Registration.FirstOrDefault(r => r.UserName == userName).Type;
        }
    }
}