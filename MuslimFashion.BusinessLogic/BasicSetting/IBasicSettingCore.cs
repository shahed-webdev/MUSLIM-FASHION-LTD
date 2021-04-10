using MuslimFashion.ViewModel;

namespace MuslimFashion.BusinessLogic
{
    public interface IBasicSettingCore
    {
        DbResponse ChangeDeliveryCharge(DeliveryChargeModel model);
        DbResponse<DeliveryChargeModel> GetDeliveryCharge();
    }
}