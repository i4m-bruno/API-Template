using System;
using System.Collections.Generic;
using System.Linq;
using Api.Service.Test;
using API.Domain.Dtos.Cep;
using API.Domain.entities;
using API.Domain.Models.Cep;
using Xunit;

namespace API.Service.Test.AutoMapper.CEPMapper
{
    public class CepMapper : BaseServiceTest
    {
        [Fact]
        public void Mapping_Cep_OK()
        {
            var model = new CepModel {
                Id = Guid.NewGuid(),
                Cep = Faker.RandomNumber.Next(1,1000).ToString(),
                Logradouro = Faker.Address.StreetName(),
                Numero = "",
                CreateAt = DateTime.UtcNow,
                UpdateAt = DateTime.UtcNow,
                MunicipioId = Guid.NewGuid()
            };

            var listaEntity = new List<CepEntity>();
            for (int i = 0 ; i < 5 ; i ++)
            {
                var item = new CepEntity {

                    Id = Guid.NewGuid(),
                    Cep = Faker.RandomNumber.Next(1,1000).ToString(),
                    Logradouro = Faker.Address.StreetName(),
                    Numero = "",
                    CreateAt = DateTime.UtcNow,
                    UpdateAt = DateTime.UtcNow,
                    MunicipioId = Guid.NewGuid(),
                    Municipio = new MunicipioEntity {
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
                    }
                };
                listaEntity.Add(item);
            }

            var entity = _mapper.Map<CepEntity>(model);
            Assert.Equal(entity.Id,model.Id);
            Assert.Equal(entity.Cep,model.Cep);
            Assert.Equal(entity.Logradouro,model.Logradouro);
            Assert.Equal(entity.MunicipioId, model.MunicipioId);
            Assert.Equal(entity.Numero,model.Numero);
            Assert.Equal(entity.CreateAt,model.CreateAt);

            var cepDto = _mapper.Map<CepDto>(entity);
            Assert.Equal(cepDto.Id,entity.Id);
            Assert.Equal(cepDto.Logradouro,entity.Logradouro);
            Assert.Equal(cepDto.Numero,entity.Numero);
            Assert.Equal(cepDto.MunicipioId,entity.MunicipioId);

            var listaDto = _mapper.Map<List<CepDto>>(listaEntity);
            Assert.True(listaDto.Count() == listaEntity.Count());
            for (int i = 0; i > listaDto.Count(); i++ )
            {
                Assert.Equal(listaDto[i].Id,listaEntity[i].Id);
                Assert.Equal(listaDto[i].Logradouro,listaEntity[i].Logradouro);
                Assert.Equal(listaDto[i].Numero,listaEntity[i].Numero);
                Assert.Equal(listaDto[i].MunicipioId,listaEntity[i].MunicipioId);
            }

            var cepDtoCreateResult = _mapper.Map<CepDtoCreateResult>(entity);
            Assert.Equal(entity.Cep,cepDtoCreateResult.Cep);
            Assert.Equal(entity.Logradouro,cepDtoCreateResult.Logradouro);
            Assert.Equal(entity.MunicipioId, cepDtoCreateResult.MunicipioId);
            Assert.Equal(entity.Numero,cepDtoCreateResult.Numero);
            Assert.Equal(entity.CreateAt,cepDtoCreateResult.CreateAt);
            
            var cepDtoUpdateResult = _mapper.Map<CepDtoUpdateResult>(entity);
            Assert.Equal(entity.Cep,cepDtoUpdateResult.Cep);
            Assert.Equal(entity.Logradouro,cepDtoUpdateResult.Logradouro);
            Assert.Equal(entity.MunicipioId, cepDtoUpdateResult.MunicipioId);
            Assert.Equal(entity.Numero,cepDtoUpdateResult.Numero);
            Assert.Equal(entity.UpdateAt,cepDtoUpdateResult.UpdateAt);

            var cepDtoCreate = _mapper.Map<CepDtoCreate>(model);
            Assert.Equal(cepDtoCreate.Numero,model.Numero);
            Assert.Equal(cepDtoCreate.Cep,model.Cep);
            Assert.Equal(cepDtoCreate.Logradouro,model.Logradouro);

            var cepDtoUpdate = _mapper.Map<CepDtoUpdate>(model);
            Assert.Equal(cepDtoUpdate.Id,model.Id);
            Assert.Equal(cepDtoUpdate.Numero,model.Numero);
            Assert.Equal(cepDtoUpdate.Cep,model.Cep);
            Assert.Equal(cepDtoUpdate.Logradouro,model.Logradouro);

        }
    }
}
