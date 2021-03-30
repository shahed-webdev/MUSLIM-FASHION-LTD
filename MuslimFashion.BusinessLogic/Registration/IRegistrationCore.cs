using MuslimFashion.Data;

namespace MuslimFashion.BusinessLogic.Registration
{
    public interface IRegistrationCore
    {
        UserType UserTypeByUserName(string userName);
    }
}