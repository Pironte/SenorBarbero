using AutoMapper;
using SenorBarbero.Data.Dtos;
using SenorBarbero.Model;

namespace SenorBarbero.UserProfile
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            CreateMap<CreateUserDto, User>().ReverseMap();
            CreateMap<BarberShopDto, BarberShop>().ReverseMap();
        }
    }
}