using AutoMapper;
using MuslimFashion.Repository;
using MuslimFashion.ViewModel;
using System;

namespace MuslimFashion.BusinessLogic
{
    public class BasicSettingCore : Core, IBasicSettingCore
    {
        public BasicSettingCore(IUnitOfWork db, IMapper mapper) : base(db, mapper)
        {
        }

        public DbResponse ChangeDeliveryCharge(DeliveryChargeModel model)
        {
            try
            {
                return _db.BasicSetting.ChangeDeliveryCharge(model);
            }
            catch (Exception e)
            {
                return new DbResponse(false, $"{e.Message}. {e.InnerException?.Message ?? ""}");
            }
        }

        public DbResponse<DeliveryChargeModel> GetDeliveryCharge()
        {
            try
            {
                var data = _db.BasicSetting.GetDeliveryCharge();
                return new DbResponse<DeliveryChargeModel>(true, "Success", data);
            }
            catch (Exception e)
            {
                return new DbResponse<DeliveryChargeModel>(false, $"{e.Message}. {e.InnerException?.Message ?? ""}");
            }
        }
    }
}