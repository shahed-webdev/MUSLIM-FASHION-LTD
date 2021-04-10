using AutoMapper;
using AutoMapper.QueryableExtensions;
using MuslimFashion.Data;
using MuslimFashion.ViewModel;
using System.Linq;

namespace MuslimFashion.Repository
{
    public class BasicSettingRepository : Repository, IBasicSettingRepository
    {
        public BasicSettingRepository(ApplicationDbContext db, IMapper mapper) : base(db, mapper)
        {

        }

        public DbResponse ChangeDeliveryCharge(DeliveryChargeModel model)
        {
            var setting = Db.BasicSetting.FirstOrDefault();
            setting.InSideDhaka = model.InSideDhaka;
            setting.OutSideDhaka = model.OutSideDhaka;
            Db.BasicSetting.Update(setting);
            Db.SaveChanges();
            return new DbResponse(true, "Delivery charge changed successfully");
        }

        public DeliveryChargeModel GetDeliveryCharge()
        {
            return Db.BasicSetting.ProjectTo<DeliveryChargeModel>(_mapper.ConfigurationProvider).FirstOrDefault();
        }
    }
}