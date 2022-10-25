using System;
using System.Threading.Tasks;
using API.Application.Controllers;
using API.Domain.Dtos.User;
using API.Domain.interfaces.Services.User;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.Usuario
{
    public class CreateRequest
    {
        private UsersController _controller;

        [Fact]
        public async Task Usuario_Criado_Sucesso()
        {
            var serviceMock = new Mock<IUserService>();
            var name = Faker.Name.First();
            var email = Faker.Internet.Email();

            serviceMock.Setup(m => m.Post(It.IsAny<UserDtoCreate>())).ReturnsAsync(
                new UserDtoCreateResult
                {
                    Id = Guid.NewGuid(),
                    Nome = name,
                    Email = email,
                    CreateAt = DateTime.UtcNow
                }
            );

            _controller = new UsersController(serviceMock.Object);
            Mock<IUrlHelper> url = new Mock<IUrlHelper>();
            url.Setup(m => m.Link(It.IsAny<string>(),It.IsAny<Object>())).Returns("http://localhost:5000");
            _controller.Url = url.Object;

            var userDtoCreate = new UserDtoCreate()
            {
                Email = email,
                Nome = name
            };

            var result = await _controller.CreateUser(userDtoCreate);
            Assert.True(result is CreatedResult);

            var resultValue = ((CreatedResult)result).Value as UserDtoCreateResult;
            Assert.NotNull(resultValue);
            Assert.Equal(userDtoCreate.Nome, resultValue.Nome);
            Assert.Equal(userDtoCreate.Email, resultValue.Email);
        }
    }
}
