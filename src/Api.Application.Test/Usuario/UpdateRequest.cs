using System;
using System.Threading.Tasks;
using API.Application.Controllers;
using API.Domain.Dtos.User;
using API.Domain.interfaces.Services.User;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace API.Application.Test.Usuario
{
    public class UpdateRequest
    {
        private UsersController _controller;

        [Fact]
        public async Task Usuario_Editado_Sucesso()
        {
            var serviceMock = new Mock<IUserService>();
            var name = Faker.Name.First();
            var email = Faker.Internet.Email();

            serviceMock.Setup(m => m.Put(It.IsAny<UserDtoUpdate>())).ReturnsAsync(
                new UserDtoUpdateResult
                {
                    Id = Guid.NewGuid(),
                    Nome = name,
                    Email = email,
                    UpdateAt = DateTime.UtcNow
                }
            );

            _controller = new UsersController(serviceMock.Object);

            var userDtoUpdate = new UserDtoUpdate()
            {
                Id = Guid.NewGuid(),
                Email = email,
                Nome = name
            };

            var result = await _controller.UpdateUser(userDtoUpdate);
            Assert.True(result is OkObjectResult);

            UserDtoUpdateResult resultValue = ((OkObjectResult)result).Value as UserDtoUpdateResult;
            Assert.NotNull(resultValue);
            Assert.Equal(userDtoUpdate.Email, resultValue.Email);
            Assert.Equal(userDtoUpdate.Nome, resultValue.Nome);
        }
    }
}
