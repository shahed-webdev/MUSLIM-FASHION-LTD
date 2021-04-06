using AutoMapper;
using MuslimFashion.Data;
using MuslimFashion.ViewModel;

namespace MuslimFashion.Repository
{
    public class CustomerMappingProfile : Profile
    {
        public CustomerMappingProfile()
        {
            CreateMap<CustomerAddWithRegistrationModel, Registration>()
                .ForMember(d => d.Customer, opt => opt.MapFrom(c => new Customer
                {
                    Name = c.Name,
                    Phone = c.Phone,
                    Email = c.Email
                }));
        }
    }
}