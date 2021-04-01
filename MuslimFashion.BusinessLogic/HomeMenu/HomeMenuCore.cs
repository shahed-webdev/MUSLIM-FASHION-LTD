using AutoMapper;
using MuslimFashion.Repository;

namespace MuslimFashion.BusinessLogic
{
    public class HomeMenuCore : Core, IHomeMenuCore
    {
        public HomeMenuCore(IUnitOfWork db, IMapper mapper) : base(db, mapper)
        {
        }
    }
}