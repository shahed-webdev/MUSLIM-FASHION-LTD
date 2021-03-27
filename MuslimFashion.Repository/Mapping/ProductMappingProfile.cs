using AutoMapper;
using MuslimFashion.Data;
using MuslimFashion.ViewModel;
using System.Linq;

namespace MuslimFashion.Repository
{
    public class ProductMappingProfile : Profile
    {
        public ProductMappingProfile()
        {
            CreateMap<ProductAddModel, Product>()
                .ForMember(d => d.ProductColors, opt => opt.MapFrom(c => c.ImageFileNames.Select(f => new ProductImage { ImageFileName = f })))
                .ForMember(d => d.ProductColors, opt => opt.MapFrom(c => c.ProductColors.Select(f => new ProductColor { ColorId = f })))
                .ForMember(d => d.ProductSizes, opt => opt.MapFrom(c => c.ProductSizes.Select(f => new ProductSize { SizeId = f })))
                ;
        }
    }
}