using System;
using System.Linq;
using System.Threading.Tasks;
using Api.Data.Test;
using API.Data.Context;
using API.Data.Implementations.Cep;
using API.Domain.entities;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace API.Data.Test
{
    public class CrudMunicipio : BaseTest , IClassFixture<DbTeste>
    {
        private ServiceProvider _serviceProvider;
        public CrudMunicipio(DbTeste dbTeste)
        {
            _serviceProvider = dbTeste.serviceProvider;
        }

        [Fact]
        [Trait("CRUD","MunicipioEntity")]
        public async void Crud_Municipio_Sucesso()
        {
            using(var context = _serviceProvider.GetService<MyContext>())
            {
                MunicipioImplementation _repositorio = new MunicipioImplementation(context);
                MunicipioEntity _entidade = new MunicipioEntity()
                {
                    Nome = Faker.Address.City(),
                    CodIBGE = Faker.RandomNumber.Next(10000,99999),
                    UfId = new Guid("971dcb34-86ea-4f92-989d-064f749e23c9")
                };

                var createResult = await _repositorio.InsertAsync(_entidade);
                Assert.NotNull(createResult);
                Assert.Equal(_entidade.Nome, createResult.Nome);
                Assert.Equal(_entidade.CodIBGE, createResult.CodIBGE);
                Assert.Equal(_entidade.UfId, createResult.UfId);
                Assert.False(createResult.Id == Guid.Empty);

                _entidade.Nome = Faker.Address.City();
                _entidade.CodIBGE = Faker.RandomNumber.Next(10000,99999);

                var updateResult = await _repositorio.UpdateAsync(_entidade);
                Assert.NotNull(updateResult);
                Assert.Equal(_entidade.Nome, updateResult.Nome);
                Assert.Equal(_entidade.CodIBGE, updateResult.CodIBGE);

                var existeResult = await _repositorio.ExistAsync(updateResult.Id);
                Assert.True(existeResult);

                var selectAllResult = await _repositorio.SelectAsync();
                Assert.NotNull(selectAllResult);
                Assert.True(selectAllResult.Count() > 0);

                var selectResult = await _repositorio.SelectAsync(updateResult.Id);
                Assert.NotNull(selectResult);
                Assert.Equal(_entidade.Nome, selectResult.Nome);
                Assert.Equal(_entidade.CodIBGE, selectResult.CodIBGE);
                Assert.Equal(_entidade.UfId, selectResult.UfId);
                Assert.Null(selectResult.Uf);

                var getResult = await _repositorio.GetById(updateResult.Id);
                Assert.NotNull(getResult);
                Assert.Equal(_entidade.Nome, getResult.Nome);
                Assert.Equal(_entidade.CodIBGE, getResult.CodIBGE);
                Assert.Equal(_entidade.UfId, getResult.UfId);
                Assert.NotNull(getResult.Uf);

                var getByIBGEResult = await _repositorio.GetByIBGECode(updateResult.CodIBGE);
                Assert.NotNull(getByIBGEResult);
                Assert.Equal(_entidade.Nome, getByIBGEResult.Nome);
                Assert.Equal(_entidade.CodIBGE, getByIBGEResult.CodIBGE);
                Assert.Equal(_entidade.UfId, getByIBGEResult.UfId);
                Assert.NotNull(getByIBGEResult.Uf);

                var deleteResult = await _repositorio.DeleteAsync(updateResult.Id);
                Assert.True(deleteResult);

                selectAllResult = await _repositorio.SelectAsync();
                Assert.True(selectAllResult.Count() == 0);

            }
        }
    }
}
