using AutoMapper;
using MuslimFashion.Data;
using MuslimFashion.Repository;

namespace MuslimFashion.BusinessLogic.Registration
{
    public class RegistrationCore : Core, IRegistrationCore
    {
        public RegistrationCore(IUnitOfWork db, IMapper mapper) : base(db, mapper)
        {
        }

        public UserType UserTypeByUserName(string userName)
        {
            return _db.Registration.UserTypeByUserName(userName);
        }
    }
}