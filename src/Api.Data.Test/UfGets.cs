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
    public class UfGets  : BaseTest , IClassFixture<DbTeste>
    {
        private ServiceProvider _serviceProvider;
        public UfGets(DbTeste dbTeste)
        {
            _serviceProvider = dbTeste.serviceProvider;
        }

        [Fact]
        [Trait("Gets","UfEntity")]
        public void E_Possivel_Realizar_Gets()
        {
            using(var context = _serviceProvider.GetService<MyContext>())
            {
                UFImplementation _repositorio = new UFImplementation(context);
                UfEntity _entity = new UfEntity()
                {
                    Id = new Guid("971dcb34-86ea-4f92-989d-064f749e23c9"),
                    Sigla = "TO",
                    Nome = "Tocantins"
                };

                var existe = _repositorio.ExistAsync(_entity.Id);
                Assert.True(existe.Result);

                var registro = _repositorio.SelectAsync(_entity.Id);
                Assert.NotNull(registro);
                Assert.Equal(registro.Result.Id, _entity.Id);
                Assert.Equal(registro.Result.Sigla, _entity.Sigla);
                Assert.Equal(registro.Result.Nome, _entity.Nome);

                var todosRegistros = _repositorio.SelectAsync();
                Assert.NotNull(todosRegistros);
                Assert.True(todosRegistros.Result.Count() > 25);
            }
        }
    }
}
