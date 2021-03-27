using AutoMapper;
using MuslimFashion.Data;
using MuslimFashion.ViewModel;

namespace MuslimFashion.Repository
{
    public class SubMenuMappingProfile : Profile
    {
        public SubMenuMappingProfile()
        {
            CreateMap<SubMenu, SubMenuAddEditModel>().ReverseMap();
            CreateMap<SubMenu, SubMenuViewModel>();
            CreateMap<SubMenu, SubMenuWithMenuModel>()
                .ForMember(d => d.MenuName, opt => opt.MapFrom(c => c.Menu.MenuName));
        }
    }
}