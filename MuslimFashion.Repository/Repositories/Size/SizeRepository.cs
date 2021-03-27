using AutoMapper;
using MuslimFashion.Data;

namespace MuslimFashion.Repository
{
    public class SizeRepository : Repository, ISizeRepository
    {
        public SizeRepository(ApplicationDbContext db, IMapper mapper) : base(db, mapper)
        {
        }
    }
}