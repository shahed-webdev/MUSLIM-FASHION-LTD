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

            CreateMap<Product, ProductDetailsModel>()
                .ForMember(d => d.ProductColors, opt => opt.MapFrom(c => c.ProductColors.Select(
                    p => new ProductColorDetailsModel
                    {
                        ColorId = p.ColorId,
                        ColorName = p.Color.ColorName,
                        ColorCode = p.Color.ColorCode
                    })))
                .ForMember(d => d.ProductSizes, opt => opt.MapFrom(c => c.ProductSizes.Select(p => new ProductSizeDetailsModel
                {
                    SizeId = p.SizeId,
                    SizeName = p.Size.SizeName,
                    Description = p.Size.Description
                })))
                .ForMember(d => d.ImageFileNames, opt => opt.MapFrom(c => c.ProductImages.Select(p => p.ImageFileName).ToArray()))
                ;

            CreateMap<Product, ProductRecordView>();
        }
    }
}