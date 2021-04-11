using AutoMapper;
using MuslimFashion.Data;
using MuslimFashion.ViewModel;

namespace MuslimFashion.Repository
{
    public class SliderMappingProfile : Profile
    {
        public SliderMappingProfile()
        {
            CreateMap<Slider, SliderCrudModel>().ReverseMap();
            CreateMap<Slider, SliderSlideModel>();
        }
    }
}