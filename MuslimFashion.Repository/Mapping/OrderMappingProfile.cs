using AutoMapper;
using MuslimFashion.Data;
using MuslimFashion.ViewModel;

namespace MuslimFashion.Repository
{
    public class OrderMappingProfile : Profile
    {
        public OrderMappingProfile()
        {


            CreateMap<OrderList, OrderReceiptItemModel>()
                .ForMember(d => d.SizeName, opt => opt.MapFrom(c => c.ProductSize.Size.SizeName))
                .ForMember(d => d.ProductCode, opt => opt.MapFrom(c => c.Product.ProductCode))
                .ForMember(d => d.ProductName, opt => opt.MapFrom(c => c.Product.ProductName))
                .ForMember(d => d.ImageFileName, opt => opt.MapFrom(c => c.Product.ImageFileName))
                .ForMember(d => d.Description, opt => opt.MapFrom(c => c.Product.Description))
                .ForMember(d => d.Brand, opt => opt.MapFrom(c => c.Product.Brand))
                .ForMember(d => d.FabricType, opt => opt.MapFrom(c => c.Product.FabricType))
                ;

            CreateMap<Order, OrderReceiptViewModel>();

            CreateMap<Order, OrderListViewModel>();
            CreateMap<OrderListAddModel, OrderList>();
            CreateMap<OrderAddModel, Order>();
            //  .ForMember(d => d.OrderLists, opt => opt.MapFrom(c => c.OrderLists));

        }
    }
}