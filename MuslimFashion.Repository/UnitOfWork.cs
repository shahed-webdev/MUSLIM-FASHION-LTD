using AutoMapper;
using MuslimFashion.Data;

namespace MuslimFashion.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public UnitOfWork(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;

            Menu = new MenuRepository(_db, _mapper);
            SubMenu = new SubMenuRepository(_db, _mapper);
        }

        public IMenuRepository Menu { get; }
        public ISubMenuRepository SubMenu { get; }

        public int SaveChanges()
        {
            return _db.SaveChanges();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}