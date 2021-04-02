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
                .ForMember(d => d.ProductSizes, opt => opt.MapFrom(c => c.ProductSizes.Select(f => new ProductSize { SizeId = f })))
                ;

            CreateMap<Product, ProductDetailsModel>()
                .ForMember(d => d.ProductSizes, opt => opt.MapFrom(c => c.ProductSizes.Select(p => new ProductSizeDetailsModel
                {
                    SizeId = p.SizeId,
                    SizeName = p.Size.SizeName,
                    Description = p.Size.Description
                })))
                ;

            CreateMap<Product, ProductRecordView>();
            CreateMap<Product, ProductGridViewModel>();
        }
    }
}