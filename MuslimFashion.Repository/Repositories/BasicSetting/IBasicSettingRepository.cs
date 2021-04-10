using MuslimFashion.ViewModel;

namespace MuslimFashion.Repository

{
    public interface IBasicSettingRepository
    {
        DbResponse ChangeDeliveryCharge(DeliveryChargeModel model);
        DeliveryChargeModel GetDeliveryCharge();
    }
}