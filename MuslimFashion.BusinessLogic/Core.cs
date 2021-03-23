using AutoMapper;
using MuslimFashion.Repository;

namespace MuslimFashion.BusinessLogic
{
    public class Core
    {
        protected readonly IUnitOfWork _db;
        protected readonly IMapper _mapper;

        public Core(IUnitOfWork db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
    }
}