using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Application.Controllers;
using API.Domain.Dtos.User;
using API.Domain.interfaces.Services.User;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.Usuario
{
    public class ListBadRequest
    {
        private UsersController _controller;

        [Fact]
        public async Task List_BadRequest()
        {
            var serviceMock = new Mock<IUserService>();

            serviceMock.Setup(m => m.List()).ReturnsAsync(
                new List<UserDto>()
                {
                    new UserDto
                    {
                        Id = Guid.NewGuid(),
                        Nome = Faker.Name.First(),
                        Email = Faker.Internet.Email(),
                    }
                }
 
            );

            _controller = new UsersController(serviceMock.Object);
            _controller.ModelState.AddModelError("id","formato inválido");

            var result = await _controller.List();
            Assert.True(result is BadRequestObjectResult);
        }
    }
}
