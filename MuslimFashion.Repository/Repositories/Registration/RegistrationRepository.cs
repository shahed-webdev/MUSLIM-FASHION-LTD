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

        public UserType UserTypeByUserName(string userName)
        {
            return Db.Registration.FirstOrDefault(r => r.UserName == userName).Type;
        }
    }
}