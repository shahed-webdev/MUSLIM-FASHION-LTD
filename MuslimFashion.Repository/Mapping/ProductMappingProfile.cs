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
                .ForMember(d => d.MenuId, opt => opt.MapFrom(c => c.SubMenu.MenuId))
                .ForMember(d => d.MenuName, opt => opt.MapFrom(c => c.SubMenu.Menu.MenuName))
                .ForMember(d => d.ProductSizes, opt => opt.MapFrom(c => c.ProductSizes.Select(p => new ProductSizeDetailsModel
                {
                    SizeId = p.SizeId,
                    SizeName = p.Size.SizeName,
                    Description = p.Size.Description
                })))
                ;

            CreateMap<Product, ProductRecordView>();
            CreateMap<Product, ProductGridViewModel>();
            CreateMap<Product, ProductFindViewModel>()
                .ForMember(d => d.Sizes, opt => opt.MapFrom(c => c.ProductSizes.Select(p => new ProductFindSizeModel
                {
                    ProductSizeId = p.ProductSizeId,
                    SizeName = p.Size.SizeName
                })))
                ;
        }
    }
}