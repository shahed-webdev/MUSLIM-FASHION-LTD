using MuslimFashion.Data;

namespace MuslimFashion.Repository
{
    public interface IRegistrationRepository
    {
        int CustomerIdByUserName(string userName);
        UserType UserTypeByUserName(string userName);
    }
}