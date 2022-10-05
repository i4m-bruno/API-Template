using API.Domain.Dtos.User;
using API.Domain.entities;
using API.Domain.Models;
using AutoMapper;

namespace API.CrossCutting.Mappings
{
    public class UserDtoToModelProfile : Profile
    {
        public UserDtoToModelProfile()
        {
            CreateMap<UserDto,UserModel>()
                .ReverseMap();

            CreateMap<UserDtoCreate, UserModel>()
                .ReverseMap();

            CreateMap<UserDtoUpdate, UserModel>()
                .ReverseMap();
        }
    }

    public class UserEntityToDtoProfile : Profile
    {
        public UserEntityToDtoProfile()
        {
            CreateMap<UserDto, UserEntity>()
                .ReverseMap();

            CreateMap<UserDtoCreateResult, UserEntity>()
                .ReverseMap();

            CreateMap<UserDtoCreate, UserEntity>()
                .ReverseMap();

            CreateMap<UserDtoUpdateResult, UserEntity>()
                .ReverseMap();
                
            CreateMap<UserDtoUpdate, UserEntity>()
                .ReverseMap();
        }
    }

    public class UserModelToEntity : Profile
    {
        public UserModelToEntity()
        {
            CreateMap<UserModel,UserEntity>()
                .ReverseMap();
        }
    }
}
