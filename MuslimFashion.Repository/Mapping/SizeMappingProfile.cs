using AutoMapper;
using MuslimFashion.Data;
using MuslimFashion.ViewModel;

namespace MuslimFashion.Repository
{
    public class SizeMappingProfile : Profile
    {
        public SizeMappingProfile()
        {
            CreateMap<Size, SizeCrudModel>().ReverseMap();
        }
    }
}