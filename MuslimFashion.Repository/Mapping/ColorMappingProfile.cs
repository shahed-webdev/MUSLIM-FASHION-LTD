using AutoMapper;
using MuslimFashion.Data;
using MuslimFashion.ViewModel;

namespace MuslimFashion.Repository
{
    public class ColorMappingProfile : Profile
    {
        public ColorMappingProfile()
        {
            CreateMap<Color, ColorCrudModel>().ReverseMap();
        }
    }
}