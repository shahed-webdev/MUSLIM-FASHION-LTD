using MuslimFashion.Data;

namespace MuslimFashion.Repository
{
    public interface IRegistrationRepository
    {
        UserType UserTypeByUserName(string userName);
    }
}