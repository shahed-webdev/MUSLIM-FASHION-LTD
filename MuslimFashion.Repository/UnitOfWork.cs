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

            BasicSetting = new BasicSettingRepository(_db, _mapper);
            Customer = new CustomerRepository(_db, _mapper);
            HomeMenu = new HomeMenuRepository(_db, _mapper);
            product = new ProductRepository(_db, _mapper);
            Menu = new MenuRepository(_db, _mapper);
            Order = new OrderRepository(_db, _mapper);
            Registration = new RegistrationRepository(_db, _mapper);
            SubMenu = new SubMenuRepository(_db, _mapper);
            Size = new SizeRepository(_db, _mapper);
        }

        public IBasicSettingRepository BasicSetting { get; }
        public ICustomerRepository Customer { get; }
        public IHomeMenuRepository HomeMenu { get; }
        public IMenuRepository Menu { get; }
        public IOrderRepository Order { get; }
        public IProductRepository product { get; }
        public IRegistrationRepository Registration { get; }
        public ISubMenuRepository SubMenu { get; }
        public ISizeRepository Size { get; }

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