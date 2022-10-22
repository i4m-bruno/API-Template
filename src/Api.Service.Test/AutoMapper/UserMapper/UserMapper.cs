using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Domain.Dtos.User;
using API.Domain.entities;
using API.Domain.Models;
using Xunit;

namespace Api.Service.Test.AutoMapper.UserMapper
{
    public class UserMapper : BaseServiceTest
    {
        [Fact(DisplayName = "AutoMapper passou em todos os testes")]
        public void Mapper_OK()
        {
            var model = new UserModel()
            {
                Id = Guid.NewGuid(),
                Nome = Faker.Name.FullName(),
                Email  = Faker.Internet.Email(),
                CreateAt = DateTime.UtcNow,
                UpdateAt = DateTime.UtcNow
            };

            // Model x Entity
            var entity = _mapper.Map<UserEntity>(model);
            Assert.Equal(model.Id, entity.Id);
            Assert.Equal(model.Nome, entity.Nome);
            Assert.Equal(model.Email, entity.Email);
            Assert.Equal(model.CreateAt, entity.CreateAt);
            Assert.Equal(model.UpdateAt, entity.UpdateAt);

            // Entity x Dto
            var dto = _mapper.Map<UserDto>(entity);
            Assert.Equal(entity.Id, dto.Id);
            Assert.Equal(entity.Nome, dto.Nome);
            Assert.Equal(entity.Email, dto.Email);
            Assert.Equal(entity.CreateAt, dto.CreateAt);
            // Entity x DtoCreate
            var dtoCreate = _mapper.Map<UserDtoCreate>(entity);
            Assert.Equal(entity.Nome, dtoCreate.Nome);
            Assert.Equal(entity.Email, dtoCreate.Email);
            // Entity x DtoCreateResult
            var dtoCreateResult = _mapper.Map<UserDtoCreateResult>(entity);
            Assert.Equal(entity.Id, dtoCreateResult.Id);
            Assert.Equal(entity.Nome, dtoCreateResult.Nome);
            Assert.Equal(entity.Email, dtoCreateResult.Email);
            Assert.Equal(entity.CreateAt, dtoCreateResult.CreateAt);
            // Entity x DtoUpdateResult
            var dtoUpdateResult = _mapper.Map<UserDtoUpdateResult>(entity);
            Assert.Equal(entity.Id, dtoUpdateResult.Id);
            Assert.Equal(entity.Nome, dtoUpdateResult.Nome);
            Assert.Equal(entity.Email, dtoUpdateResult.Email);
            Assert.Equal(entity.UpdateAt, dtoUpdateResult.UpdateAt);
            // Entity x DtoUpdate
            var dtoUpdate = _mapper.Map<UserDtoUpdate>(entity);
            Assert.Equal(entity.Id, dtoUpdate.Id);
            Assert.Equal(entity.Nome, dtoUpdate.Nome);
            Assert.Equal(entity.Email, dtoUpdate.Email);

            // Dto x Model
            var modelMap = _mapper.Map<UserModel>(dto);
            Assert.Equal(modelMap.Id, dto.Id);
            Assert.Equal(modelMap.Nome, dto.Nome);
            Assert.Equal(modelMap.Email, dto.Email);
            Assert.Equal(modelMap.CreateAt, dto.CreateAt);
            
            // Model x DtoCreate
            var dtoCreateByModel = _mapper.Map<UserDtoCreate>(modelMap);
            Assert.Equal(modelMap.Nome, dtoCreateByModel.Nome);
            Assert.Equal(modelMap.Email, dtoCreateByModel.Email);
            // Model x DtoUpdate
            var dtoUpdateByModel = _mapper.Map<UserDtoUpdate>(modelMap);
            Assert.Equal(modelMap.Id, dtoUpdateByModel.Id);
            Assert.Equal(modelMap.Nome, dtoUpdateByModel.Nome);
            Assert.Equal(modelMap.Email, dtoUpdateByModel.Email);
        }
    }
}
