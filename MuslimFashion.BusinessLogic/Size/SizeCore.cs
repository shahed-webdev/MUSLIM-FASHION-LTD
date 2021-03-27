using AutoMapper;
using MuslimFashion.Repository;

namespace MuslimFashion.BusinessLogic
{
    public class SizeCore : Core, ISizeCore
    {
        public SizeCore(IUnitOfWork db, IMapper mapper) : base(db, mapper)
        {
        }
    }
}