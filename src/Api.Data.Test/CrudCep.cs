using System;
using System.Linq;
using Api.Data.Test;
using API.Data.Context;
using API.Data.Implementations.Cep;
using API.Domain.entities;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace API.Data.Test
{
    public class CrudCep : BaseTest , IClassFixture<DbTeste>
    {
        private ServiceProvider _serviceProvider;
        public CrudCep(DbTeste dbTeste)
        {
            _serviceProvider = dbTeste.serviceProvider;
        }

        [Fact]
        [Trait("CRUD","CepEntity")]
        public async void Crud_Cep_Sucesso()
        {
            using(var context = _serviceProvider.GetService<MyContext>())
            {
                MunicipioImplementation _repositorioMunicipio = new MunicipioImplementation(context);
                MunicipioEntity _entidadeMunicipio = new MunicipioEntity()
                {
                    Nome = Faker.Address.City(),
                    CodIBGE = Faker.RandomNumber.Next(10000,99999),
                    UfId = new Guid("971dcb34-86ea-4f92-989d-064f749e23c9")
                };

                var createMunicipioResult = await _repositorioMunicipio.InsertAsync(_entidadeMunicipio);
                Assert.NotNull(createMunicipioResult);
                Assert.Equal(_entidadeMunicipio.Nome, createMunicipioResult.Nome);
                Assert.Equal(_entidadeMunicipio.CodIBGE, createMunicipioResult.CodIBGE);
                Assert.Equal(_entidadeMunicipio.UfId, createMunicipioResult.UfId);
                Assert.False(createMunicipioResult.Id == Guid.Empty);

                CepImplementation _repositorioCep = new CepImplementation(context);
                CepEntity _entidadeCep = new CepEntity()
                {
                    Cep = "12.123-123",
                    Logradouro = Faker.Address.StreetName(),
                    Numero = "100 a 900",
                    MunicipioId = createMunicipioResult.Id
                };

                var createCepResult = await _repositorioCep.InsertAsync(_entidadeCep);
                Assert.NotNull(createCepResult);
                Assert.Equal(_entidadeCep.Cep, createCepResult.Cep);
                Assert.Equal(_entidadeCep.Logradouro, createCepResult.Logradouro);
                Assert.Equal(_entidadeCep.MunicipioId, createCepResult.MunicipioId);
                Assert.Equal(_entidadeCep.Numero, createCepResult.Numero);

                _entidadeCep.Logradouro = Faker.Address.StreetName();
                _entidadeCep.Numero = "900 a 999";
                _entidadeCep.Cep = "00.111-222";

                var updateResult = await _repositorioCep.UpdateAsync(_entidadeCep);
                Assert.NotNull(updateResult);
                Assert.Equal(_entidadeCep.Cep, updateResult.Cep);
                Assert.Equal(_entidadeCep.Logradouro, updateResult.Logradouro);
                Assert.Equal(_entidadeCep.Numero, updateResult.Numero);

                var existeResult = await _repositorioCep.ExistAsync(updateResult.Id);
                Assert.True(existeResult);

                var selectResult = await _repositorioCep.SelectAsync(updateResult.Id);
                Assert.NotNull(selectResult);
                Assert.Equal(_entidadeCep.Cep, selectResult.Cep);
                Assert.Equal(_entidadeCep.Logradouro, selectResult.Logradouro);
                Assert.Equal(_entidadeCep.Numero, selectResult.Numero);

                var selectByCepResult = await _repositorioCep.SelectAsync(updateResult.Cep);
                Assert.NotNull(selectByCepResult);
                Assert.NotNull(selectByCepResult.Municipio);
                Assert.NotNull(selectByCepResult.Municipio.Uf);
                Assert.Equal(_entidadeCep.Cep, selectByCepResult.Cep);
                Assert.Equal(_entidadeCep.Logradouro, selectByCepResult.Logradouro);
                Assert.Equal(_entidadeCep.Numero, selectByCepResult.Numero);

                var selectAllResult = await _repositorioCep.SelectAsync();
                Assert.NotNull(selectAllResult);
                Assert.True(selectAllResult.Count() > 0);

                var deleteResult = await _repositorioCep.DeleteAsync(updateResult.Id);
                Assert.True(deleteResult);

                selectAllResult = await _repositorioCep.SelectAsync();
                Assert.True(selectAllResult.Count() == 0);
            }
        }
    }
}
