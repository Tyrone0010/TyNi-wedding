using AutoMapper;
using TyNi.Wedding.Infrastructure.Models;
using TyNi.Wedding.ViewModels;

namespace TyNi.Wedding.App_Start
{
    public class AutoMapperConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile(new CustomerProfile());
            });
        }
    }

    public class CustomerProfile : Profile
    {
        public CustomerProfile() 
        {
            CreateMap<Customer, CustomerVm>().ReverseMap();
        }
    }
}