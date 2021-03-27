using AutoMapper;
using MuslimFashion.Data;
using MuslimFashion.ViewModel;

namespace MuslimFashion.Repository
{
    public class MenuMappingProfile : Profile
    {
        public MenuMappingProfile()
        {
            CreateMap<Menu, MenuCrudModel>().ReverseMap();

            CreateMap<Menu, MenuWithSubMenuViewModel>()
                .ForMember(d => d.SubMenus, opt => opt.MapFrom(c => c.SubMenus));
        }
    }
}