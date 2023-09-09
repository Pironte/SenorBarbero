using AutoMapper;
using SenorBarbero.Data.Dtos;
using SenorBarbero.Model;

namespace SenorBarbero.Profiles
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            CreateMap<CreateUserDto, User>().ReverseMap();
            CreateMap<BarberShopDto, BarberShop>().ReverseMap();
            CreateMap<ServiceDto, Service>().ReverseMap();
            CreateMap<ScheduleDto, Schedule>().ReverseMap();
            CreateMap<ScheduleSlotDto, ScheduleSlot>().ReverseMap();
        }
    }
}