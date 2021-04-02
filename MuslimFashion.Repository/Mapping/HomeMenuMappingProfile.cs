using AutoMapper;
using MuslimFashion.Data;
using MuslimFashion.ViewModel;

namespace MuslimFashion.Repository
{
    public class HomeMenuMappingProfile : Profile
    {
        public HomeMenuMappingProfile()
        {
            CreateMap<HomeMenuCrudModel, HomeMenu>().ReverseMap();
            CreateMap<HomeMenu, HomeMenuWithProductModel>().ReverseMap();
        }
    }
}