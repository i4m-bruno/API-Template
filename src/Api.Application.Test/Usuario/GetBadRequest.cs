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
    public class GetBadRequest
    {
        private UsersController _controller;

        [Fact]
        public async Task Get_BadRequest()
        {
            var serviceMock = new Mock<IUserService>();
            var name = Faker.Name.First();
            var email = Faker.Internet.Email();

            serviceMock.Setup(m => m.Get(It.IsAny<Guid>())).ReturnsAsync(
                new UserDto
                {
                    Id = Guid.NewGuid(),
                    Nome = name,
                    Email = email,
                }
            );

            _controller = new UsersController(serviceMock.Object);
            _controller.ModelState.AddModelError("id","id nulo");

            var result = await _controller.Get(default(Guid));
            Assert.True(result is BadRequestObjectResult);
        }
    }
}
