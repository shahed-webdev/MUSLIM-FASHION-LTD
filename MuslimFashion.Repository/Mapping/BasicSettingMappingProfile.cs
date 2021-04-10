using AutoMapper;
using MuslimFashion.Data;
using MuslimFashion.ViewModel;

namespace MuslimFashion.Repository
{
    public class BasicSettingMappingProfile : Profile
    {
        public BasicSettingMappingProfile()
        {
            CreateMap<DeliveryChargeModel, BasicSetting>();
        }
    }
}