using System;
using System.Linq;
using System.Threading.Tasks;
using API.Data.Context;
using API.Data.Implementations;
using API.Domain.entities;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Api.Data.Test
{
    public class CrudUsuario : BaseTest, IClassFixture<DbTeste>
    {
        private ServiceProvider _serviceProvider;

        public CrudUsuario(DbTeste dbTeste)
        {
            _serviceProvider = dbTeste.serviceProvider;
        }

        [Fact(DisplayName="Crud usuário")]
        [Trait("CRUD","USER")]
        public async Task CrudUsuarioComSucesso()
        {
            using(var context = _serviceProvider.GetService<MyContext>())
            {
                UserImplementation _repository = new UserImplementation(context);

                UserEntity _entity = new UserEntity()
                {
                    Email = Faker.Internet.Email(),
                    Nome = Faker.Name.FullName()
                };

                var result = await _repository.InsertAsync(_entity);

                Assert.NotNull(result);
                Assert.Equal(_entity.Email,result.Email);
                Assert.Equal(_entity.Nome,result.Nome);
                Assert.False(result.Id == Guid.Empty);

                //testando editar
                result.Nome = Faker.Name.First();
                var entidadeAlterada = await _repository.UpdateAsync(result);
                Assert.NotNull(entidadeAlterada);
                Assert.Equal(result.Email, entidadeAlterada.Email);
                Assert.Equal(result.Nome, entidadeAlterada.Nome);

                //testando select
                var resultSelect = await _repository.SelectAsync(entidadeAlterada.Id);
                Assert.NotNull(resultSelect);
                Assert.Equal(resultSelect.Email, entidadeAlterada.Email);

                //testando selectAll
                var listResult = await _repository.SelectAsync();
                Assert.NotNull(listResult);
                Assert.True(listResult.Count() > 1);

                //testando exists
                var resultExist = await _repository.ExistAsync(result.Id);
                Assert.True(resultExist);

                //testando findByLogin
                var resultFindByLogin = await _repository.FindByLogin(entidadeAlterada.Email);
                Assert.NotNull(resultFindByLogin);
                Assert.Equal(entidadeAlterada.Email, resultFindByLogin.Email);

                //testando delete
                var resultDelete = await _repository.DeleteAsync(result.Id);
                Assert.True(resultDelete);

            }
        }
    }
}
