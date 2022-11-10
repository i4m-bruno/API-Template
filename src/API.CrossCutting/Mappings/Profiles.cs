using API.Domain.Dtos.Cep;
using API.Domain.Dtos.UF;
using API.Domain.Dtos.User;
using API.Domain.entities;
using API.Domain.Models;
using API.Domain.Models.Cep;
using AutoMapper;

namespace API.CrossCutting.Mappings
{
    public class DtoToModelProfile : Profile
    {
        public DtoToModelProfile()
        {
            CreateMap<UserDto,UserModel>()
                .ReverseMap();

            CreateMap<UserDtoCreate, UserModel>()
                .ReverseMap();

            CreateMap<UserDtoUpdate, UserModel>()
                .ReverseMap();
            
            CreateMap<UfDto, UfModel>()
                .ReverseMap();

            CreateMap<MunicipioDto, MunicipioModel>()
                .ReverseMap();

            CreateMap<MunicipioDtoCreate, MunicipioModel>()
                .ReverseMap();

            CreateMap<MunicipioDtoUpdate, MunicipioModel>()
                .ReverseMap();
            
            CreateMap<CepDto, CepModel>()
                .ReverseMap();
            
            CreateMap<CepDtoCreate, CepModel>()
                .ReverseMap();
            
            CreateMap<CepDtoUpdate, CepModel>()
                .ReverseMap();
        }
    }

    public class EntityToDtoProfile : Profile
    {
        public EntityToDtoProfile()
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

            CreateMap<UfDto, UfEntity>()
                .ReverseMap();

            CreateMap<MunicipioDto, MunicipioEntity>()
                .ReverseMap();

            CreateMap<MunicipioDtoCreateResult, MunicipioEntity>()
                .ReverseMap();

            CreateMap<MunicipioDtoUpdateResult, MunicipioEntity>()
                .ReverseMap();
            
            CreateMap<CepDto, CepEntity>()
                .ReverseMap();
            
            CreateMap<CepDtoCreateResult, CepEntity>()
                .ReverseMap();
            
            CreateMap<CepDtoUpdateResult, CepEntity>()
                .ReverseMap();
        }
    }

    public class ModelToEntity : Profile
    {
        public ModelToEntity()
        {
            CreateMap<UserModel,UserEntity>()
                .ReverseMap();
            
            CreateMap<UfEntity, UfModel>()
                .ReverseMap();

            CreateMap<MunicipioEntity, MunicipioModel>()
                .ReverseMap();
            
            CreateMap<CepEntity, CepModel>()
                .ReverseMap();
        }
    }
}
