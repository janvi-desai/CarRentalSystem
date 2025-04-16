using AutoMapper;
using CarRentalSystem.Data;
using CarRentalSystem.Models;

namespace CarRentalSystem.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Car, CarModel>().ReverseMap();
            CreateMap<Payment, PaymentModel>().ReverseMap();
            CreateMap<SystemSetting, SystemSettingModel>().ReverseMap();
            CreateMap<Rental, RentalModel>().ReverseMap();  
            CreateMap<CarImage, CarImageModel>().ReverseMap();  
        }
    }

}
