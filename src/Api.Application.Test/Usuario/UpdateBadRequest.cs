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
    public class UpdateBadRequest
    {
        private UsersController _controller;

        [Fact]
        public async Task Usuario_Editado_BadRequest()
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
            _controller.ModelState.AddModelError("name","Nome vazio");

            var userDtoUpdate = new UserDtoUpdate()
            {
                Id = Guid.NewGuid(),
                Email = email,
                Nome = name
            };

            var result = await _controller.UpdateUser(userDtoUpdate);
            Assert.True(result is BadRequestObjectResult);
        }
    }
}
