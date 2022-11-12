using System;
using System.Collections.Generic;
using System.Linq;
using Api.Service.Test;
using API.Domain.Dtos.UF;
using API.Domain.entities;
using API.Domain.Models.Cep;
using Xunit;

namespace API.Service.Test.AutoMapper.CEPMapper
{
    public class MunicipioMapper : BaseServiceTest
    {
        [Fact]
        public void Mapping_Municipio_OK()
        {
            var model = new MunicipioModel {
                Id = Guid.NewGuid(),
                CodIBGE = Faker.RandomNumber.Next(1,9999),
                Nome = Faker.Address.City(),
                UfId = Guid.NewGuid(),
                CreateAt = DateTime.UtcNow,
                UpdateAt = DateTime.UtcNow,
            };

            var listaEntity = new List<MunicipioEntity>();
            for ( int i = 0; i < 5; i++ )
            {
                var item = new MunicipioEntity {
                    Id = Guid.NewGuid(),
                    CodIBGE = Faker.RandomNumber.Next(1,9999),
                    Nome = Faker.Address.City(),
                    UfId = Guid.NewGuid(),
                    CreateAt = DateTime.UtcNow,
                    UpdateAt = DateTime.UtcNow,
                    Uf = new UfEntity {
                        Id = Guid.NewGuid(),
                        Nome = Faker.Address.UsState(),
                        Sigla = Faker.Address.UsState().Substring(1,3)
                    }
                };
                listaEntity.Add(item);
            }

            var entity = _mapper.Map<MunicipioEntity>(model);
            Assert.Equal(model.Id, entity.Id);
            Assert.Equal(model.CodIBGE, entity.CodIBGE);
            Assert.Equal(model.Nome, entity.Nome);
            Assert.Equal(model.UfId, entity.UfId);
            Assert.Equal(model.CreateAt, entity.CreateAt);
            Assert.Equal(model.UpdateAt, entity.UpdateAt);

            var dto = _mapper.Map<MunicipioDto>(entity);
            Assert.Equal(dto.Id, entity.Id);
            Assert.Equal(dto.CodIBGE, entity.CodIBGE);
            Assert.Equal(dto.Nome, entity.Nome);
            Assert.Equal(dto.UfId, entity.UfId);

            var dtoCreate = _mapper.Map<MunicipioDtoCreate>(model);
            Assert.Equal(dtoCreate.CodIBGE, model.CodIBGE);
            Assert.Equal(dtoCreate.Nome, model.Nome);
            Assert.Equal(dtoCreate.UfId, model.UfId);

            var dtoUpdate = _mapper.Map<MunicipioDtoUpdate>(model);
            Assert.Equal(dtoUpdate.CodIBGE, model.CodIBGE);
            Assert.Equal(dtoUpdate.Nome, model.Nome);
            Assert.Equal(dtoUpdate.UfId, model.UfId);

            var listaDto = _mapper.Map<List<MunicipioDto>>(listaEntity);
            Assert.True(listaDto.Count() == listaEntity.Count());
            for (int i = 0; i < listaDto.Count(); i ++)
            {
                Assert.Equal(listaDto[i].Id, listaEntity[i].Id);
                Assert.Equal(listaDto[i].CodIBGE, listaEntity[i].CodIBGE);
                Assert.Equal(listaDto[i].Nome, listaEntity[i].Nome);
                Assert.Equal(listaDto[i].UfId, listaEntity[i].UfId);
            }

            var dtoCreateResult = _mapper.Map<MunicipioDtoCreateResult>(entity);
            Assert.Equal(dtoCreateResult.Id, entity.Id);
            Assert.Equal(dtoCreateResult.CodIBGE, entity.CodIBGE);
            Assert.Equal(dtoCreateResult.Nome, entity.Nome);
            Assert.Equal(dtoCreateResult.UfId, entity.UfId);
            Assert.Equal(dtoCreateResult.CreateAt, entity.CreateAt);

            var dtoUpdateResult = _mapper.Map<MunicipioDtoUpdateResult>(entity);
            Assert.Equal(dtoUpdateResult.Id, entity.Id);
            Assert.Equal(dtoUpdateResult.CodIBGE, entity.CodIBGE);
            Assert.Equal(dtoUpdateResult.Nome, entity.Nome);
            Assert.Equal(dtoUpdateResult.UfId, entity.UfId);
            Assert.Equal(dtoUpdateResult.UpdateAt, entity.UpdateAt);
        }
    }
}
