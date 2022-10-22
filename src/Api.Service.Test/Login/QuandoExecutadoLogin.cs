using System;
using Api.Service.Test.UserTestes;
using API.Domain.Dtos;
using API.Domain.interfaces.Services.User;
using Moq;
using Xunit;

namespace Api.Service.Test.Login
{
    public class QuandoExecutadoLogin : UserTest
    {
        private ILoginService _service;
        private Mock<ILoginService> _serviceMock;

        [Fact]
        public async void Login_Success()
        {
            var email = Faker.Internet.Email();
            
            var retorno = new 
            {
                authenticated = true,
                created = DateTime.UtcNow,
                expires = DateTime.UtcNow.AddDays(1),
                accessToken = Guid.NewGuid(),
                userName = email,
                mail = Faker.Name.FullName(),
                message = "Logado com sucesso"
            };

            var loginDto = new LoginDto()
            {
                Email = email
            };

            _serviceMock = new Mock<ILoginService>();
            _serviceMock.Setup(m => m.FindByLogin(loginDto)).ReturnsAsync(retorno);
            _service = _serviceMock.Object;

            var result = await _service.FindByLogin(loginDto);
            Assert.NotNull(result);
        }
    }
}
