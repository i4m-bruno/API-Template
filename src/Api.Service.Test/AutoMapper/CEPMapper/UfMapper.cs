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
    public class UfMapper : BaseServiceTest
    {
        [Fact(DisplayName = "Mapping de uf OK")]
        public void Mapping_UF_OK()
        {
           var model = new UfModel {
                Id = Guid.NewGuid(),
                Nome = Faker.Address.UsState(),
                Sigla = Faker.Address.UsState().Substring(1,3),
                CreateAt = DateTime.UtcNow,
                UpdateAt = DateTime.UtcNow
           };

           var entidades = new List<UfEntity>();
           for (int i = 0 ; i < 5; i++)
           {
                var entidade = new UfEntity
                {
                    Id = Guid.NewGuid(),
                    Nome = Faker.Address.UsState(),
                    Sigla = Faker.Address.UsState().Substring(1,3),
                    CreateAt = DateTime.UtcNow,
                    UpdateAt = DateTime.UtcNow
                };
                entidades.Add(entidade);
           }

           // model => entity
           var entity = _mapper.Map<UfEntity>(model);
           Assert.Equal(entity.Id,model.Id);
           Assert.Equal(entity.Nome,model.Nome);
           Assert.Equal(entity.Sigla,model.Sigla);
           Assert.Equal(entity.CreateAt,model.CreateAt);
           Assert.Equal(entity.UpdateAt,model.UpdateAt);

           // entity => dto
           var ufDto = _mapper.Map<UfDto>(entity);
           Assert.Equal(ufDto.Id,entity.Id);
           Assert.Equal(ufDto.Nome,entity.Nome);
           Assert.Equal(ufDto.Sigla,entity.Sigla);
           // listEntity => listDto
           var listaDto = _mapper.Map<List<UfDto>>(entidades);
           Assert.True(listaDto.Count() == entidades.Count());
           for (int i = 0; i < listaDto.Count; i++)
           {
            Assert.Equal(listaDto[i].Id,entidades[i].Id);
            Assert.Equal(listaDto[i].Nome,entidades[i].Nome);
            Assert.Equal(listaDto[i].Sigla,entidades[i].Sigla);
           }

           // dto => model
           var ufmodel = _mapper.Map<UfModel>(ufDto);
           Assert.Equal(ufDto.Id,ufmodel.Id);
           Assert.Equal(ufDto.Nome,ufmodel.Nome);
           Assert.Equal(ufDto.Sigla,ufmodel.Sigla);
        }
    }
}
