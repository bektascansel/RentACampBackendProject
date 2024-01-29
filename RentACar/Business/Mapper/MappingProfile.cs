using AutoMapper;
using Entities.Concrete;
using Entities.Concrete.DTOs.BrandDto;
using Entities.Concrete.DTOs.CarDto;
using Entities.Concrete.DTOs.ColorDto;
using Entities.Concrete.DTOs.CustomerDto;
using Entities.Concrete.DTOs.RentalDto;
using Entities.Concrete.DTOs.UserDto;
using Core.Entities.Concrete;

namespace Business.Mapper
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {


            CreateMap<AddColorDto, Color>();
            CreateMap<AddBrandDto, Brand>();
            CreateMap<AddCarDto, Car>();
            CreateMap<UpdateCarDto, Car>();
            CreateMap<AddUserDto,User>();
            CreateMap<AddCustomerDto, Customer>();
            CreateMap<UpdateCustomerDto, Customer>();
            CreateMap<UpdateRentalDto, Rental>();
            CreateMap<AddRentalDto, Rental>();
            CreateMap<UpdateUserDto, User>();
            CreateMap<User, GetUserDto>();




        }

    }
}
